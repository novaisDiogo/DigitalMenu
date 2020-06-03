using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Banco
{
    public interface ICaminho
    {
        string ObterCaminho(string nomeArquivoBanco);
    }
}
