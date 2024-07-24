using NoriuValgyti.Core.Interfaces;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.Extensions.Configuration;

namespace NoriuValgyti.Infrastructure.ExternalServices;

public class ImageService : IImageService
{
    private readonly IConfiguration _configuration;
    public ImageService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Stream ConvertBase64ToStream(string imageFromRequest)
    {
        byte[] imageStringToBase64 = Convert.FromBase64String(imageFromRequest);
        StreamContent streamContent = new(new MemoryStream(imageStringToBase64));
        return streamContent.ReadAsStream();
    }
    
    public async Task<string> UploadImage(Stream stream, string imageName)
    {
        string _firebaseStorageApiKey = _configuration.GetSection("Firebase")["FirebaseStorageApiKey"];
        string _firebaseStorageAuthEmail = _configuration.GetSection("Firebase")["FirebaseStorageAuthEmail"];
        string _firebaseStorageAuthPassword = _configuration.GetSection("Firebase")["FirebaseStorageAuthPassword"];
        string _firebaseStorageBucket = _configuration.GetSection("Firebase")["FirebaseStorageBucket"];

        
        FirebaseAuthProvider firebaseConfiguration = new(new FirebaseConfig(_firebaseStorageApiKey));

        FirebaseAuthLink authConfiguration = await firebaseConfiguration
            .SignInWithEmailAndPasswordAsync(_firebaseStorageAuthEmail, _firebaseStorageAuthPassword);

        CancellationTokenSource cancellationToken = new CancellationTokenSource();
        
        FirebaseStorageTask storageManager = new FirebaseStorage(
                _firebaseStorageBucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(authConfiguration.FirebaseToken),
                    ThrowOnCancel = true
                })
            .Child(imageName)
            .PutAsync(stream, cancellationToken.Token);
        
        string imageFromFirebaseStorage = await storageManager;
        
        return imageFromFirebaseStorage;
    }
}