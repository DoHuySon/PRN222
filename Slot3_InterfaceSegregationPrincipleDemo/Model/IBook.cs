﻿namespace Slot3_InterfaceSegregationPrincipleDemo.Model
{
    internal interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        double Price { get; set; }
    }
    interface ITopic
    {
        string Topic { get; set; }
    }
    interface IDuration
    {
        string Duration { get; set; }
    }
}
