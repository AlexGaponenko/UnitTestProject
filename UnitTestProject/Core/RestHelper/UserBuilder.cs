using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Core.RestHelper
{
    class UserBuilder
    {
        private int id;
        private string username;

        UserBuilder() { }

        public UserBuilder(int id, string username)
        {
            this.id = id;
            this.username = username;

        }

        public int getId() { return id; }
        public string getUsername() { return username; }

        abstract class Builder
        {
        private int id;
        private string username;
        }





    }
}
