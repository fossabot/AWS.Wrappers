
using System.Text;

namespace AWS.S3.Wrapper.Tests;

[Collection("Our Test Collection #1")]
public class FileMetadataOperationsTests : TestBase, IDisposable
{
    private readonly List<string> _createdBucketNames = new();

    [Fact]
    public async Task GetObjectMetadataAsync_ShouldGetAddedMetadataOfS3Object()
    {
        // arrange
        var bucketName = $"{_bucketPrefix}-{Guid.NewGuid()}";
        await _bucketOperations.CreateBucketAsync(bucketName, cancellationToken);

        var objectKey = "my-object";
        var content = new MemoryStream(Encoding.UTF8.GetBytes("Hello World!"));
        var contentType = "text/plain";

        // act
        await _fileOperations.UploadFileStreamAsync(bucketName, objectKey, content, contentType, cancellationToken);

        var metadata = new Dictionary<string, string>
        {
            { "key1", "value1" },
            { "key2", "value2" }
        };

        var metadataOutput = new Dictionary<string, string>
        {
            { "x-amz-meta-key1", "value1" },
            { "x-amz-meta-key2", "value2" }
        };

        await _fileMetadataOperations.UpdateObjectMetadataAsync(bucketName, objectKey, metadata, cancellationToken);

        // act
        var actualMetadata = await _fileMetadataOperations.GetObjectMetadataAsync(bucketName, objectKey, cancellationToken);

        // assert
        Assert.Equal(metadataOutput, actualMetadata);

        _createdBucketNames.Add(bucketName);
    }
    public void Dispose()
    {
        foreach (var bucketName in _createdBucketNames)
        {
            _bucketOperations.EmptyBucketAsync(bucketName, cancellationToken).Wait();
            _bucketOperations.DeleteBucketAsync(bucketName, cancellationToken).Wait();
        }
    }
}
