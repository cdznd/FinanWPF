using System;
using System.Collections.Generic;
using System.Text;

using FinanWPF.Models;

namespace FinanWPF.Controllers
{
    class SingleContext
    {

        private static Context _context;

        public static Context GetInstance()
        {

            if(_context == null)
            {

                _context = new Context();

            }

            return _context;

        }

    }
}
