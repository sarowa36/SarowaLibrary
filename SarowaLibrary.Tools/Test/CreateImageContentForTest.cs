namespace SarowaLibrary.ToolsLayer.Test
{
    public static class CreateImageContentForTest
    {
        /// <summary>
        /// Creating a image for test purpose
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns><code>ByteArrayContent</code></returns>
        public static ByteArrayContent Create(string? filePath=null)
        {
            if(filePath == null)
            {
                filePath = @".\Test\test.png";
            }
           var upfilebytes = File.ReadAllBytes(filePath);
           return new ByteArrayContent(upfilebytes);
        }
    }
}
