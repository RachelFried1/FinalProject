using Microsoft.AspNetCore.Http;


public class ResumeService
{
    private readonly string _uploadsFolder;

    public ResumeService()
    {
        // Define the directory to save the files
        _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedResumes");
        if (!Directory.Exists(_uploadsFolder))
        {
            Directory.CreateDirectory(_uploadsFolder);
        }
    }

    public async Task UploadResumeAsync(int jobOfferCode, IFormFile resumeFile)
    {
        // Validate and save the file
        ValidateFile(resumeFile);
        string filePath = Path.Combine(_uploadsFolder, $"{jobOfferCode}{Path.GetExtension(resumeFile.FileName)}");
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await resumeFile.CopyToAsync(stream);
        }
    }

    public FileStream GetResume(int jobOfferCode, out string contentType, out string fileName)
    {
        // Retrieve the file
        string[] matchingFiles = Directory.GetFiles(_uploadsFolder, $"{jobOfferCode}.*");
        if (matchingFiles.Length == 0)
            throw new FileNotFoundException("Resume not found.");

        string filePath = matchingFiles[0];
        fileName = Path.GetFileName(filePath);
        contentType = GetContentType(filePath);
        return new FileStream(filePath, FileMode.Open, FileAccess.Read);
    }

    private void ValidateFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is required.");

        string extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        string contentType = file.ContentType.ToLowerInvariant();

        var allowedExtensions = new[] { ".pdf", ".docx" };
        var allowedMimeTypes = new[]
        {
        "application/pdf",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
        };

        if (!allowedExtensions.Contains(extension) || !allowedMimeTypes.Contains(contentType))
            throw new ArgumentException("Only PDF or DOCX files are allowed.");
    }


    private string GetContentType(string filePath)
    {
        // Determine content type based on file extension
        string extension = Path.GetExtension(filePath).ToLowerInvariant();
        return extension switch
        {
            ".pdf" => "application/pdf",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            _ => "application/octet-stream"
        };
    }
}
