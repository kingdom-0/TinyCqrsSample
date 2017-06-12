﻿using System;

namespace TinyCqrsSample.Core.Domain.Mementos
{
    public class DiaryItemMemento : BaseMemento
    {
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public DateTime From { get; internal set; }
        public DateTime To { get; internal set; }
        public int EventVersion { get; set; }

        public DiaryItemMemento(Guid id, string title, string description, DateTime from, DateTime to, int version)
        {
            Title = title;
            Id = id;
            Description = description;
            From = from;
            To = to;
            Version = version;
            EventVersion = version;
        }
    }
}