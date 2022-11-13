using APIMusicEntities.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace APIMusic.Models.Responses
{
    public class TheSongResponse
    {
        public string Name { get; set; }
        public Array Singers { get; set; }
        public string Path { get; set; }
        public string Image { get; set; }
    }

}
