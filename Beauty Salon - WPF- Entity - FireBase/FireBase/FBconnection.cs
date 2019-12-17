using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetraEntity.FireBase
{
    class FBconnection
    {

        public IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "**************************",
            BasePath = "******************************"
        };

        public IFirebaseClient client;
        public FirebaseResponse response;


    }
}
