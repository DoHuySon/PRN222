﻿namespace Slot3_LiskovSubstitutionPrincipleDemo.Model
{
    internal interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        double Price { get; set; }
    }
}
