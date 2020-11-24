using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;

namespace BULL
{
    public class PhiTreHenBUL
    {
        PhiTreHenRepository phiTreHen;

        public PhiTreHenBUL()
        {
            phiTreHen = new PhiTreHenRepository();
        }

        public double getTotalPhiTreHen(int idkh, double phi)
        {
            return phiTreHen.totatlPhiTreHen(idkh, phi);
        }
    }
}
