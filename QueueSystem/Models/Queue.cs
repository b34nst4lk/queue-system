using System;
using System.Collections.Generic;

namespace QueueSystem.Models
{
    public enum QueueType
    {
        Registered = 'R',
        WalkIn = 'W'
    }

    public enum Status
    {
        Waiting = 0,
        Calling = 1,
        Called = 2,
        Missed = 3,
        Completed = 4,
    }

    public partial class Queue
    {
        private char queueType;

        public int QueueNo { get; set; }
        public char QueueType {
            get => queueType;
            set
            {
                if (Enum.IsDefined(typeof(QueueType), value))
                    queueType = value;
                else
                    throw new ArgumentException(
                        string.Format("{0} is an invalid QueueType. Only values 'R' and 'W' are allowed", value)
                    );
            }
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Status Status { get; set; }

        public Queue() { }

        public Queue(char qType)
        {
            QueueType = qType;
            CreatedAt = DateTime.Now;
            UpdatedAt = CreatedAt;
        }
    }
}
