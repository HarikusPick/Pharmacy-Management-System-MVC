using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using eczane1.Models;

namespace eczane1.Security
{
    public class MyRoles : RoleProvider
    {
        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }

        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {

            string[] roller = new string[1];
            string tip = null;
            int a=-1;
            EczaneDataBaseEntities3 n = new EczaneDataBaseEntities3();
            tbl_kullanici kullanici = n.tbl_kullanici.FirstOrDefault(x=>x.kullanici_nickname == username);
            tbl_admin admin = n.tbl_admin.FirstOrDefault(x=>x.admin_nickname == username);
            tbl_eczane eczane = n.tbl_eczane.FirstOrDefault(x=>x.eczane_nickname == username);
            if (kullanici != null)
            {
                tip = kullanici.tbl_rol.rol_ad.ToString();
                a++;
                roller[a] = tip;
            }
            if(admin!= null)
            {
                tip = admin.tbl_rol.rol_ad.ToString();
                a++;
                roller[a] = tip;
            }
            if (eczane != null)
            {
                tip = eczane.tbl_rol.rol_ad.ToString();
                a++;
                roller[a] = tip;
            }
            Console.WriteLine(roller+"<--------------------------");

            return roller;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}