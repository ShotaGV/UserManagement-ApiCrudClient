using ApiCrudClient.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Server.HttpSys;

namespace ApiCrudClient
{
    public class APIGateway 
    {
        private string url = "https://localhost:7161/api/User";
        private string accessToken = "CfDJ8GpuWLEkT19LjQpmzBNhTy2r5HLg91MN1MVe_wXT7F0ndsyI7tx6kC5PpZOCfazo4tsNeoToFxqwNWWzmZ_dZJjfsCzO5kBnEXdL9x98BpEZC2bpuoZ_zzhYcLawDQmJXiGXLRaQVdi3nfWUFnHA98L38eUjrdaRGZnYn-Le_qGfkz5fAlTC4b4JzUVjjLlNAC0V1TOZSGLBZyJ_ap36FI_06V9ZIRrKa7nP7E3xy0u4wWDdwLT5Bn18FZ98im0an3sR8P2BQ8obcIZgs461oy3uR-qon2zUut_5bv4y6FX5G_K8qc7dDwHQoiFNJJCZjV_4tA8jaMMeRPCsxtzJtYHQKsLV9GQIXB4MebQUW_Z6bEip5UcqIRJcD36QIOjTgmBJsBX5eN8QiRQPlTPNwPET6bfxhQilcVUnJSlMDG9y0zKg9Ye11Xp1aIvOIh30BGc9HvY4KQLkFvpt3uXnkdrEPErWVII3e_o8zYMDv3mSK9kOBwkMcoJjmdusJ1bzbiME01HC5Y7b8Q3L_wx3E0baISCCA2S7d-fQWEc1-LQZA-MzlcDHTO_4FIDVEt9aD7wehlzFB196ifSkg4iDRE1OGUYLjBU82y25oYk2R4eNDf764YkexkkMXoSUSYQfWYCps0gloEqXDvZJEt0ZiBxfZ_kdXbDqn-HXQS5cHv9Kx8Ixf_oqsLsR8uWvpCx32w";
        private HttpClient httpclient = new HttpClient();


        public List<User> ListUsers()
        {
            List<User> users = new List<User>();
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = httpclient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<User>>(result);
                    if (datacol != null)
                        users = datacol;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured At The API Endpoint, Error Info " + result);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error Occured At The API Endpoint, Error Info " + ex.Message);
            }
            finally { }
            return users;
        }
        public User CreateUser(User user)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(user);
            try 
            {
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = httpclient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<User>(result);
                    if (data != null)
                        user = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured At The API Endpoint, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured At The API Endpoint, Error Info " + ex.Message);
            }
            finally { }
            return user;
        }
        public User GetUser(int ID)
        {
            User user = new User();
            url = url + "/" + ID;

            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = httpclient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<User>(result);
                    if (data != null)
                        user = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured At The API Endpoint, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured At The API Endpoint, Error Info " + ex.Message);
            }
            finally { }
            return user;
        }
        public void UpdateUser(User user)
        {
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            int ID = user.ID;
            url = url + "/" + ID;
            string json = JsonConvert.SerializeObject(user);
            try
            {

                HttpResponseMessage response = httpclient.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured At The API Endpoint, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured At The API Endpoint, Error Info " + ex.Message);
            }
            finally { }
            return;
        }
        public void DeleteUser(int ID)  
        {
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            url = url + "/" + ID;
            try
            {
                HttpResponseMessage response = httpclient.DeleteAsync(url).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured At The API Endpoint, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured At The API Endpoint, Error Info " + ex.Message);
            }
            finally { }
            return;
        }
    }
}
