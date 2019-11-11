﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using App5.Entity;
using Newtonsoft.Json;

namespace App5.Service
{
    class MemberService : IMemberService
    {
        public Member Register(Member member)
        {
            
            var httpClient = new HttpClient();
      
            var dataToSend = JsonConvert.SerializeObject(member);
          
            var content = new StringContent(dataToSend, Encoding.UTF8, "application/json");
           
            var response = httpClient.PostAsync(ProjectConfiguration.MEMBER_REGISTER_URL, content).GetAwaiter().GetResult();
         
            var jsonContent = response.Content.ReadAsStringAsync().Result;
           
            var responseMember = JsonConvert.DeserializeObject<Member>(jsonContent);
     
            Debug.WriteLine("Register success with id: " + responseMember.id);
            return responseMember;
        }

        public MemberCredential Login(MemberLogin memberLogin)
        {
            var httpClient = new HttpClient();
            var dataToSend = JsonConvert.SerializeObject(memberLogin);
            var content = new StringContent(dataToSend, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(ProjectConfiguration.MEMBER_LOGIN_URL, content).GetAwaiter().GetResult();
            var memberCredential = JsonConvert.DeserializeObject<MemberCredential>(response.Content.ReadAsStringAsync().Result);
            return memberCredential;
        }

        public Member GetInformation(string token)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(token);
            var response = httpClient.GetAsync(ProjectConfiguration.MEMBER_GET_INFORMATION).GetAwaiter().GetResult();
            var member = JsonConvert.DeserializeObject<Member>(response.Content.ReadAsStringAsync().Result);
            return member;
        }
    }
}
