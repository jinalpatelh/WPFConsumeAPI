using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaseLibrary
{
    public class ComicProcessor
    {
        public async static Task<ComicModel> LoadComic(int comicNumber=0)
        {
            string url = "";
            
            if(comicNumber > 0)
            {
                url = $"http://xkcd.com/{ comicNumber }/info.0.json";
            }
            else
            {
                url = "http://xkcd.com/info.0.json";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
