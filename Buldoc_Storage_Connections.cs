using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Azure.Storage.Blobs;
using Azure.Identity;
using Azure.Storage.Blobs.Models;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;

using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Diagnostics.Contracts;
using System.Windows.Forms.VisualStyles;
using OfficeOpenXml;
using FuzzyString;

namespace Buldoc_Reader_Take_4
{
    public class Buldoc_Storage_Connections
    {

        // List of our records
        public List<AudioRecord> AudioRecords;
        public List<VideoRecord> VideoRecords;  
        public List<ImageRecord> ImageRecords;
        

        private List<String> Audio_URLS = new List<String>();
        private List<String> Video_URLS = new List<String>();
        private List<String> Image_URLS = new List<String>();
        public String Audio_folder_physical_location = @"C:\Users\willh\OneDrive\Coding Stuff\Visual Studio Stuff\Buldoc Reader Take 4\BlobURLS\Audio_URLS.txt";
        public String Video_folder_physical_location = @"C:\Users\willh\OneDrive\Coding Stuff\Visual Studio Stuff\Buldoc Reader Take 4\BlobURLS\Video_URLS.txt";
        public String Image_folder_physical_location = @"C:\Users\willh\OneDrive\Coding Stuff\Visual Studio Stuff\Buldoc Reader Take 4\BlobURLS\Image_URLS.txt";
        public String Restricted_Audio_physical_location = @"C:\Users\willh\OneDrive\Coding Stuff\Visual Studio Stuff\Buldoc Reader Take 4\BlobURLS\Restricted_Content.txt";
        public String Sources_folder_physical_location = @"C:\Users\willh\OneDrive\Coding Stuff\Visual Studio Stuff\Buldoc Reader Take 4\BlobURLS\Source_URLS.txt";

        public String Image_Descriptions_physical = @"C:\Users\willh\OneDrive\Coding Stuff\Visual Studio Stuff\Buldoc Reader Take 4\BlobURLS\Pictures index 9-14-2021.xlsx";
        public String Video_Descriptions_physical = @"C:\Users\willh\OneDrive\Coding Stuff\Visual Studio Stuff\Buldoc Reader Take 4\BlobURLS\video index.xlsx";
        public String Audio_Descriptions_physical = @"C:\Users\willh\OneDrive\Coding Stuff\Visual Studio Stuff\Buldoc Reader Take 4\BlobURLS\audio tapes index.xlsx";

        public String Audio_folder_virtual_location = @"~/BlobURLS/Audio_URLS.txt";
        public String Video_folder_virtual_location = @"~/BlobURLS/Video_URLS.txt";
        public String Image_folder_virtual_location = @"~/BlobURLS/Image_URLS.txt";
        public String Restricted_Audio_virtual_location = @"~/BlobURLS/Restricted_Content.txt";
        public String Sources_folder_virtual_location = @"~/BlobURLS/Source_URLS.txt";

        public String Image_Descriptions_virtual = @"~/BlobURLS/Pictures index 9-14-2021.xlsx";





        public BlobServiceClient create_client()
        {
            BlobServiceClient blobserviceclient = new BlobServiceClient(new Uri("https://frbuldocsite.blob.core.windows.net"), new DefaultAzureCredential());

            return blobserviceclient;
        }

        public Boolean check_file_existence(String Filepath)
        {
            if (File.Exists(Filepath))
            {

                return true;
            }

            else
            {
                return false;
            }
        }

        public void generate_Audio_Urls(BlobServiceClient client, string audio_mapped_path, string restricted_mapped_path, bool test)
        {
            if (test == true)
            {
                audio_mapped_path = Audio_folder_physical_location;
                restricted_mapped_path = Restricted_Audio_physical_location;
            }

            if (check_file_existence(restricted_mapped_path) != true)
            {
                File.Create(restricted_mapped_path);
            }

            if (check_file_existence(audio_mapped_path) != true)
            {
                File.Create(audio_mapped_path);
            }


            //Wipe the file completely --> Will make an admin location to refresh URLS at periodic intervals
       

            try // will only work if file already exists
            {
                StreamReader audio_reader = new StreamReader(audio_mapped_path); // If file doesnt exist, will break and head to the exception clause


                int linecount = 0;

                while (audio_reader.ReadLine() != null)
                {
                    linecount++;
                }

                audio_reader.Close();

                StreamReader restricted_audio_reader = new StreamReader(restricted_mapped_path);

                int restricted_linecount = 0;

                while (restricted_audio_reader.ReadLine() != null)
                {
                    restricted_linecount++;
                }

                restricted_audio_reader.Close();





                string audio_container = "buldocaudio";
                BlobContainerClient audio_container_client = client.GetBlobContainerClient(audio_container);
                var audio_blobs = audio_container_client.GetBlobs();
                audio_blobs.OrderBy(s => s.Name);


                if (audio_blobs.Count() != linecount || audio_blobs.Count() != restricted_linecount)
                {
                    File.WriteAllText(audio_mapped_path, ""); // Makes file blank - will redo the content inside of it
                    File.WriteAllText(restricted_mapped_path, "");
                    //BlobContainerClient audio_container_client = client.GetBlobContainerClient(audio_container);
                    //var audio_blobs = audio_container_client.GetBlobs
                    //

                    StreamWriter restricted_audio_writer = new StreamWriter(restricted_mapped_path, true);

                    StreamWriter audio_writer = new StreamWriter(audio_mapped_path, true);
                    foreach (BlobItem item in audio_blobs)
                    {
                        var full_url = "https://frbuldocsite.blob.core.windows.net/buldocaudio/" + item.Name;

                        if (full_url.Contains("/3-") || full_url.Contains("/Carlita"))
                        {
                            restricted_audio_writer.WriteLine(full_url);
                        }
                        else
                        {
                            audio_writer.WriteLine(full_url);
                        }
                    }
                    audio_writer.Flush();
                    audio_writer.Close();
                    restricted_audio_writer.Flush();
                    restricted_audio_writer.Close();
                }

            }

            catch (Exception e) // File does not exist
            {
                StreamWriter audio_writer = new StreamWriter(audio_mapped_path, true); //will create a file by default
                string audio_container = "buldocaudio";

                BlobContainerClient audio_container_client = client.GetBlobContainerClient(audio_container);
                var audio_blobs = audio_container_client.GetBlobs();
                foreach (BlobItem item in audio_blobs)
                {
                    var full_url = "https://frbuldocsite.blob.core.windows.net/buldocaudio/" + item.Name;
                    audio_writer.WriteLine(full_url);
                }
                audio_writer.Flush();
                audio_writer.Close();
            }
        }

        public void generate_video_urls(BlobServiceClient client)
        {
            //Wipe the file completely --> Will make an admin location to refresh URLS at periodic intervals
            File.Delete(Video_folder_physical_location);

            StreamWriter writer = new StreamWriter(Video_folder_physical_location, true);
            string video_container = "buldocvideos";

            BlobContainerClient video_container_client = client.GetBlobContainerClient(video_container);
            var video_blobs = video_container_client.GetBlobs();
            foreach (BlobItem item in video_blobs)
            {
                var full_url = "https://frbuldocsite.blob.core.windows.net/buldocvideos/" + item.Name;
                writer.WriteLine(full_url);
            }
            writer.Flush();
            writer.Close();



        }



        public void generate_image_urls(BlobServiceClient client)
        {

            //Wipe the file completely --> Will make an admin location to refresh URLS at periodic intervals
            File.Delete(Image_folder_physical_location);

            StreamWriter image_writer = new StreamWriter(Image_folder_physical_location, true);
            string image_container = "buldocimages";

            BlobContainerClient image_container_client = client.GetBlobContainerClient(image_container);
            var image_blobs = image_container_client.GetBlobs();
            foreach (BlobItem item in image_blobs)
            {
                var full_url = "https://frbuldocsite.blob.core.windows.net/buldocimages/" + item.Name;
                image_writer.WriteLine(full_url);
            }
            image_writer.Flush();
            image_writer.Close();

        }

        public void generate_Source_URLS(BlobServiceClient client)
        {
            if (check_file_existence(Sources_folder_physical_location) != true)
            {
                File.Create(Sources_folder_physical_location);

            }

            File.Delete(Sources_folder_physical_location);


            StreamWriter source_writer = new StreamWriter(Sources_folder_physical_location, true);
            string source_container = "buldocsources";

            BlobContainerClient sources_container_client = client.GetBlobContainerClient(source_container);
            var source_blobs = sources_container_client.GetBlobs();


            source_blobs.OrderBy(s => s.Name);
            var name_list = new List<String>();


            foreach (BlobItem item in source_blobs)
            {
                var full_url = "https://frbuldocsite.blob.core.windows.net/buldocsources/" + item.Name;
                source_writer.WriteLine(full_url);
            }

            source_writer.Flush();
            source_writer.Close();

        }

        public void generate_image_descriptions()
        {
            String Image_text_file = Image_folder_physical_location;

            string[] lines = File.ReadAllLines(Image_text_file);

            File.WriteAllText(Image_text_file, string.Empty);

            StreamWriter writer = new StreamWriter(Image_folder_physical_location, true);



            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string file_path = this.Image_Descriptions_physical;

            using (var package = new ExcelPackage(new System.IO.FileInfo(file_path)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Assuming you have data in columns A and B, you can read it like this:
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    // Access cell data by row and column
                    var picture_number = worksheet.Cells[row, 1].Text;
                    var picture_description = worksheet.Cells[row, 5].Text;

                    foreach (string line in lines)
                    {
                        if (line.Contains(("p" + picture_number + ".jpg")))
                        {
                            writer.WriteLine(line + "_" + picture_number + "_" + picture_description);
                        }

                        else if (line.Contains(("p" + picture_number + ".JPG")))
                        {
                            writer.WriteLine(line + "_" + picture_number + "_" + picture_description);
                        }

                        else if (line.Contains(("p" + picture_number + ".jpeg")))
                        {
                            writer.WriteLine(line + "_" + picture_number + "_" + picture_description);
                        }
                    }



                }

                writer.Flush();
                writer.Close();
            }

        }

        public void generate_video_descriptions()
        {
            String Video_text_file = Video_folder_physical_location;

            string[] lines = File.ReadAllLines(Video_text_file);

            File.WriteAllText(Video_text_file, string.Empty);

            StreamWriter writer = new StreamWriter(Video_text_file, true);



            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string file_path = this.Video_Descriptions_physical;

            using (var package = new ExcelPackage(new System.IO.FileInfo(file_path)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Assuming you have data in columns A and B, you can read it like this:
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    // Access cell data by row and column
                    var video_name = worksheet.Cells[row, 1].Text;
                    var videodescription = worksheet.Cells[row, 2].Text;

                    foreach (string line in lines)
                    {
                        if (line.Contains(video_name)) 
                        {
                            writer.WriteLine(line + "*" + videodescription);
                            break;
                        }

                    }



                }

                writer.Flush();
                writer.Close();
            }



        }

        public void generate_audio_descriptions()
        {
            string Audio_text_file = Audio_folder_physical_location;

            string[] lines = File.ReadAllLines(Audio_text_file);

            File.WriteAllText(Audio_text_file, string.Empty);

            StreamWriter writer = new StreamWriter(Audio_text_file, true);



            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string file_path = this.Audio_Descriptions_physical;

            using (var package = new ExcelPackage(new System.IO.FileInfo(file_path)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Assuming you have data in columns A and B, you can read it like this:
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    // Access cell data by row and column
                    var recording_name = worksheet.Cells[row, 1].Text;
                    var recording_description = worksheet.Cells[row, 2].Text;

                    foreach (string line in lines)
                    {
                        double similarity = line.JaccardDistance(recording_name);
                        if (similarity>= 0.7)
                        {
                            writer.WriteLine(line + "*" + recording_description);
                            break;
                        }
                    }



                }

                writer.Flush();
                writer.Close();
            }
        }
    }
}
