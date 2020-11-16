using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Start_Template.ServerModals
{
    public class ItemResponse<T>
    {

        public T Item { get; set; }

        public bool IsSuccessful { get; set; }

        public string TransactionId { get; set; }

        public ItemResponse()
        {
            this.IsSuccessful = true;

            this.TransactionId = Guid.NewGuid().ToString();
        }

    }
}
