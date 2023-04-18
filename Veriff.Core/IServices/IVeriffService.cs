using System;
using System.Collections.Generic;
using System.Text;
using Veriff.Core.Model;

namespace Veriff.Core.IServices
{
    public interface IVeriffService
    {
        bool CreateVeriffSession(verification verification);
    }
}
