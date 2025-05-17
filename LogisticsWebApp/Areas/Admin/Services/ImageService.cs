namespace LogisticsWebApp.Areas.Admin.Services
{
    public static class ImageService
    {
      /// <summary>
      /// This method is used to Delete the specified image from the specified folder of the wwwroot/Uploads.
      /// </summary>
      /// <param name="imagename"> Provide the Name of the image which you want to delete</param>
      /// <param name="foldername">Prvode the folder name e.g. wwwroot/Uploads/FolderName</param>
      /// <param name="webHostEnvironment"> Provide the intialized object of the IWebHostEnvironment</param>
        public static void DeleteImage(string imagename,string foldername, IWebHostEnvironment webHostEnvironment)
        {
            var FolderPath = Path.Combine(webHostEnvironment.WebRootPath, $"Uploads/{foldername}");
            var ImagePath = Path.Combine(FolderPath, imagename);
            if (System.IO.File.Exists(ImagePath))
            {
                System.IO.File.Delete(ImagePath);
            }
        }

    }
}
