using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueueSystem.Models
{
    public class QueueService
    {
        public QueueSystemContext context;

        public QueueService()
        {
            context = new QueueSystemContext();
        }

        public Queue Register(QueueType qType)
        {
            Queue newNo = new Queue((char) qType);
            context.Queue.Add(newNo);
            context.SaveChanges();
            return newNo;
        }

        public void Reregister(string queueNo)
        {
            char qType = queueNo[0];
            if (Enum.IsDefined(typeof(QueueType), qType))
            {
                int qNo = Convert.ToInt32(queueNo.Substring(1, 4));
                context.Queue.First(q => q.QueueNo == qNo);
            }
        }

    }
}
