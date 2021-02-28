using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using vittighedsmaskinen.apikey;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vittighedsmaskinen.Controllers
{
    
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet]
        [Route("/")]
        public IEnumerable<string> Get()
        {
            return new string[] { "kategorierne på dansk er: yamammajoke, dadjoke, dirtyjoke", "den eneste katekori på engelsk er dog puns", "eksempel på valg af kategori: https://localhost:44300/api/Home/ca?category=dadjoke", "eksmpel på valg sprog: https://localhost:44300/api/Home/la?language=en kun dk og en", "få en joke ved at skrive https://localhost:44300/api/Home/joke" };
        }

        // GET api/<HomeController>/5
        [Route("la")]
        [HttpGet]
        public string GetLanguage(string language)
        {
            if (language != null)
            {
                CookieOptions co = new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddYears(1)
                };
                Response.Cookies.Append("language", language, co);
            }
            return "Præference er sat";
        }
        [Route("ca")]
        [HttpGet]
        public string GetCategory(string category)
        {
            if (category != null)
            {
                CookieOptions co = new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(1)
                };
                Response.Cookies.Append("Category", category, co);
            }
            return "Præference er sat";
        }
        [Route("joke")]
        [HttpGet]
        public string GetJoke()
        {
            bool validJoke = false;
            string joke = "";
            List<string> jokes = new List<string>();
            
            
            jokes.Add("");
            Debug.WriteLine(Request.Cookies["Category"]);
            string category = "";
            if (Request.Cookies["Category"]!=null)
            {
                category = Request.Cookies["Category"];
            }
            if (HttpContext.Session.GetObjectFromJson<List<string>>("Joke") != null)
            {
                jokes = HttpContext.Session.GetObjectFromJson<List<string>>("Joke");
            }
            
            while (validJoke == false)
            {
                if (Request.Cookies["language"] == "en")
                {
                    category = "enJokes";
                    joke = DAL.Joke(category);
                    
                }
                else
                {
                    joke = DAL.Joke(category);
                }

                
                Debug.WriteLine(DAL.ListLenght(category));
                if (jokes.Count+1 == DAL.ListLenght(category))
                {
                    validJoke = true;
                    joke = "no more jokes";
                    break;
                }
                else
                {
                    foreach (string item in jokes)
                    {
                        if (item == joke)
                        {
                            validJoke = false;
                            break;
                        }
                        else
                        {
                            validJoke = true;
                        }

                    }
                }
                
                
            }
            
            GetSaidJoke(joke);
            return joke;
        }
        
        public void GetSaidJoke(string joke)
        {
            List<string> jokes = new List<string>();
            if (HttpContext.Session.GetObjectFromJson<List<string>>("Joke") != null)
            {
                jokes = HttpContext.Session.GetObjectFromJson<List<string>>("Joke");
                jokes.Add(joke);
                HttpContext.Session.SetObjectAsJson("Joke", jokes);
            }
            else
            {
                jokes.Add(joke);
                HttpContext.Session.SetObjectAsJson("Joke", jokes);
            }
                
        }
        [Route("pro")]
        [HttpGet]
        [Authorize (Policy = Policies.OnlyProgrammers)]
        public string ProgrammerJoke()
        {
            return "why do Java programmers have to wear glasses? - becuse they don't c#";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
