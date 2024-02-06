using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
public class CompradorLoginRepostory
{
    public string Username { get; set; }
    public string Senha { get; set; }
}