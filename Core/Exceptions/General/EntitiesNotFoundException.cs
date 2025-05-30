﻿using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.General
{
    public class EntitiesNotFoundException : NotFoundBaseException
    {
        public List<int>? Ids { get; set; }


        /// <summary>
        /// Varsayılan mesaj yerine, özel bir hata mesajı tanımlamak için kullanılır.
        /// </summary>
        public EntitiesNotFoundException(string message, bool isCustomMessage) : base(message)
        {
        }



        /// <summary>
        /// Gönderdiğiniz bu {name} mevcutta yok!
        /// </summary>
        public EntitiesNotFoundException(string name) : base($"Gönderdiğiniz bu {name} mevcutta yok!")
        {
        }


        /// <summary>
        /// Gönderdiğiniz bu {name}, {modelName} içinde yok!
        /// </summary>
        public EntitiesNotFoundException(string name, string modelName) : base($"Gönderdiğiniz bu {name}, {modelName} içinde yok!")
        {
        }
    }
}
