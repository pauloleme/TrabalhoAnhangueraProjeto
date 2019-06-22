
using System;
using System.Collections;
using System.IO;

namespace Competicao_lol
{
    class Program
    {
        //ENDEREÇOS PARA ONDE IRÁ O ARQUIVO .TXT
        static string ficheiro = @"C:\Users\Public\competicao.txt";
        static StreamWriter file;
        static ArrayList times = new ArrayList();
        //---------------------------------------------------------------------
        // 0 - ARQUIVO PRINCIPAL DO PROGRAMA, SEM ELE NENHUM MÓDULO FUNCIONARIA
        //---------------------------------------------------------------------
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White; //define a cor do fundo de tela no console para branco
            CarregarArquivoCompeticao(); //traz o módulo responsável por carregar o arquivo criado pelo streamwriter para o método main
            Escolher(); //exibe o menu que permite ao usuário escolher a função desejada.
        }
        //--------------------------------------------------------
        // 1 - CARREGAR AS LINHAS INSERIDAS NO ARQUIVO DO FICHEIRO
        //--------------------------------------------------------
        static void CarregarArquivoCompeticao() //declara o módulo "CarregarArquivoCompeticao"
        {
            //CARREGANDO OS ARQUIVOS DO FICHEIRO
            if (File.Exists(ficheiro))  // se o arquivo "ficheiro" existe, executará o comando abaixo
            {
                string[] linhas = File.ReadAllLines(ficheiro);// lê todo o conteudo do "ficheiro" e guarda no Array
                foreach (string linha in linhas) // lê todo o conteúdo do array recém-criado
                {
                    string[] partes = linha.Split('|'); //reparte o contido no array de acordo com o sinal escolhido e salva em um novo array(partes)
                    Time time = new Time(); //cria novo objeto na classe "Time"
                    time.nome = partes[0]; // atribui o valor contido na posição 0 do array "partes" à variável "nome" contida no objeto "time"
                    int c = 0; // declara uma variável que funcionará como contador
                    for (int i = 0; i < 5; i++) // realizará o processo abaixo 5 vezes
                    {
                        Jogador jogador = new Jogador(); //declara novo objeto na classe "jogador"
                        jogador.nome = partes[i + 1 + c]; //atribui o valor armazenado na posição de número equivalente às somas dos valores das variáveis 
                        jogador.posicao = partes[i + 2 + c];//atribui o valor armazenado na posição de número equivalente às somas dos valores das variáveis  
                        time.jogadores.Add(jogador); // salva o jogador recém-criado no arraylist existente na classe "time"
                        c++; // incrementa o contador
                    }
                    times.Add(time); // adiciona o time recém-criado ao arraylist "times" presente na classe "Program"
                }
            }
        }
        //--------------------------------------------
        // 2 - ESCOLHER A OPÇÃO QUE DESEJA NO PROGRAMA
        //--------------------------------------------
        static void Escolher() //declara o módulo "Escolher"
        {
            char opcao = ' '; // declara uma variável vazia cujo nome é "opcao"
            do // faz o programa executar os próximos comandos, até que certa condição seja atingida
            {
                Console.Clear(); //limpa o console
                Console.ForegroundColor = ConsoleColor.Red; // define a cor de primeiro plano do console como vermelhas
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t\tMENU\t\tCBLOL\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.ForegroundColor = ConsoleColor.Black; // define a cor de primeiro plano do console como pretas
                Console.WriteLine("|1- Inserir Times\t\t\t\t     |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|2- Alterar ou Remover Times\t\t\t     |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|3- Consultar Times ou Jogadores\t\t     |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|4- Listar Times, Jogadores e Posições\t\t     |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|0- Sair\t\t\t\t\t     |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.Write("|Insira a Opção:");
                opcao = char.Parse(Console.ReadLine()); //atribui um valor à variável "opcao"

                switch (opcao) // de acordo com o valor dado à variável, escolherá automaticamente a próxima ação do console entre as seguintes
                {
                    case '1': // para 1 como valor
                        Inserir(); // evocará o módulo "Inserir"
                        break; // e parará a execução do switch case
                    case '2': // para 2 como valor
                        AlterarRemover(); //evocará o módulo "AlterarRemover"
                        break;// e parará a execução do switch case
                    case '3':// para 3 como valor
                        Consultar();//evocará o módulo "Consultar"
                        break;// e parará a execução do switch case
                    case '4':// para 4 como valor
                        Listar();//evocará o módulo "Listar"
                        break;// e parará a execução do switch case
                    default: //se não está entre as opções pré-definidas, executará esta parte do código
                        if (opcao != '0') // se diferente de 0
                        {
                            Console.WriteLine("Opção Inválida!!"); // exibirá no console o texto
                        }
                        break; //e parará a execução do switch case
                }
            } while (opcao != '0'); // determina a condição que encerrará a execução do DO, ou seja, enquanto diferente de 0 o DO continuará a executar
        }
        //---------------------------------------
        // 3 - INSERIR OS TIMES/JOGADORES/POSIÇÕES
        //---------------------------------------
        static void Inserir() //declara o módulo "Inserir"
        {
            do  // faz o programa executar os próximos comandos, até que certa condição seja atingida
            {
                Console.Clear();//limpa o console
                bool encontrado = false; // declara uma variável do tipo bool e atribui a ela o valor false 

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    CADASTRO\t\tCBLOL\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Time time1 = new Time(); //declara novo objeto dentro da classe "Time"
                Console.WriteLine("|                                                    |");
                Console.Write("| Time: \t\t");
                time1.nome = Console.ReadLine(); //atribui valor à variável "nome" do objeto recém-criado

                foreach (Time time in times) //executa a leitura do arraylist "times", que contém os dados da classe "Time"
                {
                    if (time.nome.ToLower().Contains(time1.nome.ToLower())) // condiciona o programa para que, se a variável "time.nome" contida no arraylist for igual a recém-criada "time1.nome",
                                                                            // seja executada determinada função
                    {
                        encontrado = true; //caso o if seja cumprido, a variável bool "encontrado" receberá o valor true
                        Console.Clear(); // limpa o console

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    CADASTRO\t\tCBLOL\t\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|\n| O time {0} já foi adicionado.", time.nome); // exibe que o time inserido na variável "time1.nome" já foi adicionado anteriormente na
                                                                                            // variável "time.nome"
                        Console.WriteLine("|\n|\n| Escolha a opção:");
                        Console.WriteLine("|\n| 1- Adicionar outro time\n| 2- Menu incial");
                        Console.Write("|\n|Insira a Opção:");
                        string opcao = Console.ReadLine(); //declara nova variável "opcao" e atribui o valor digitado pelo usuário a ela
                        if (opcao == "1") //se 1
                        {
                            Inserir(); //voltará ao início do módulo "Inserir"
                        }
                        else if (opcao == "2") //se 2
                        {
                            Escolher(); //voltará ao menu "Escolher"
                        }
                        else // caso nenhum destes
                        {
                            Console.WriteLine("Opção inválida!"); // exibirá que nenhuma opção válida foi escolhida
                        }
                    }
                }
                if (!encontrado) // caso não encontre o time dentre os já salvos
                {
                    string linha = time1.nome + "|"; //inserirá na variável "linha" o contido na variável "time1.nome", seguido de uma barra reta
                    for (int i = 0; i < 5; i++) // em seguida executará por 5 vezes
                    {
                        Jogador jogador = new Jogador(); // a criação de novos jogadores na classe "Jogador"
                        Console.Write("|\n| Nome do jogador: \t");
                        jogador.nome = Console.ReadLine(); // os quais terão as variáveis correspondentes a seus nomes 
                        Console.Write("|\n| Posição do jogador: \t");
                        jogador.posicao = Console.ReadLine(); // e posições preenchidas pelo usuário
                        linha += jogador.nome + "|" + jogador.posicao + "|";
                        time1.jogadores.Add(jogador); // adiciona ao arraylist "time1.jogadores" o objeto "jogador"
                    }
                    times.Add(time1); // adiciona "time1" ao arraylist "times"
                    //SALVANDO OS DADOS NO FICHEIRO
                    if (File.Exists(ficheiro)) //se o arquivo "ficheiro" existe
                    {
                        file = File.AppendText(ficheiro); // posiciona na última linha do arquivo o cursor
                    }
                    else // se não 
                    {
                        file = File.CreateText(ficheiro); // criar o arquivo "ficheiro"
                    }
                    file.WriteLine(linha); // escreve no arquivo o texto salvo na variável "linha"
                    file.Close(); // fecha e salva o arquivo
                    Console.Write("|\n| Deseja continuar inserindo times ? s p/ sim e n p/ não: \t"); // exibe para o usuário: deseja continuar inserindo times?
                }
            } while (Console.ReadLine().ToLower() == "s"); // aqui, se o console receber "s" do usuário, reiniciará o loop  do "DO While", caso contrário passará para a próxima linha do código
            Console.Clear(); //limpa o console
            Escolher();//volta para o módulo "Escolha"
        }
        //------------------------------------------
        // 4 - ALTERAR OU REMOVER TIMES JÁ INSERIDOS
        //------------------------------------------
        static void AlterarRemover() // declara o módulo "AlterarRemover"
        {
            Console.Clear(); // limpa o console

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|\t    ESCOLHER\t\tCBLOL\t\t     |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| Escolha qual opção deseja:                         |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| 1- Alterar\t\t\t\t\t     |\n| 2- Remover\t\t\t\t\t     |\n| 3- Ir ao Menu inicial\t\t\t\t     |"); // exibe as opções presentes nesse menu ao usuário
            Console.WriteLine("|                                                    |");
            Console.Write("| Insira a Opção:");

            string opcao = Console.ReadLine(); // declara a variável "opção"  e define que ela receberá o valor dado pelo usuário
            if (opcao == "1") // se o valor atribuído à variável "opção" for 1, então 
            {
                Console.Clear(); // o console será limpo

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    ALTERAR TIME\tCBLOL\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.Write("| Insira o nome do time que quer alterar: "); // e solicitará ao usuário que digite o nome do time a ser alterado
                string nome = Console.ReadLine(); //declara a variável "nome" e define que ela receberá o valor digitado pelo usuário
                bool encontrado = false; // declara nova variável do tipo boolean com valor false 
                int count = 0; // declara variável, que funcionará como um contador, e atribui a ela o valor 0
                int countAlterar = 0;// declara uma segunda variável, que funcionará como um contador, e atribui a ela o valor 0
                string linha; // declara uma variável que armazenará os dados inseridos pelo usuário após selecionar qual time irá alterar
                Time time1 = new Time(); // declara novo objeto na classe "Time"
                foreach (Time time in times) // lê todo o arraylist "times", passando por seu conteúdo um a um, executando os próximos comandos em cada um deles
                {
                    if (time.nome.ToLower().Contains(nome.ToLower())) // compara o contido na variável "time.nome", convertida em letras minúsculas, com o texto contido na variável "nome" 
                    {                                                                                            // caso o conteúdo exista dentro da variável, convertido em letras minúsculas, executará os comandos a seguir
                        countAlterar = count; //atribui o valor da variável "count" à "countAlterar"
                        encontrado = true; //atribui o valor true à variável booleana previamente criada

                        Console.Clear(); // limpa o console

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    ALTERAR TIME\tCBLOL\t\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|\n| O time {0} foi encontrado.", time.nome); // informa que a comparação foi validada
                        Console.WriteLine("|\n| Deseja alterar-lo? s p/ sim"); // e pergunta se deseja executar a alteração
                        if (Console.ReadLine().ToLower() == "s") //caso a resposta seja "S" 
                        {
                            Console.Clear(); // o console será limpo

                            Console.WriteLine("|----------------------------------------------------|");
                            Console.WriteLine("|                                                    |");
                            Console.WriteLine("|\t    ALTERAR TIME\tCBLOL\t\t     |");
                            Console.WriteLine("|                                                    |");
                            Console.WriteLine("|----------------------------------------------------|");

                            Console.Write("| Time: \t\t"); // e será solicitada a inserção do novo time, que substituirá o solicitado pelo usuário
                            time1.nome = Console.ReadLine(); //atribui o valor digitado pelo usuário à variável "time1"
                            linha = time1.nome + "|"; // atribui à variável "linha" o valor contido na variável "time1.nome" mais uma barra reta
                            for (int i = 0; i < 5; i++) // executa 5 vezes os comandos a seguir
                            {
                                Jogador jogador = new Jogador(); // declara novo objeto dentro da classe "Jogador"
                                Console.Write("|\n| Nome do jogador: \t");
                                jogador.nome = Console.ReadLine(); //atribui o valor digitado pelo usuário à variável "nome" dentro do objeto "jogador"
                                Console.Write("|\n| Posição do jogador: \t");
                                jogador.posicao = Console.ReadLine(); // atribui o valor digitado à variável "posição" dentro do objeto "Jogador" 
                                linha += jogador.nome + "|" + jogador.posicao + "|"; // concatena o valor já existente na variável com os valores digitados anteriormente,
                                                                                     //em "nome" e "posição", e os separa por uma barra reta
                                time1.jogadores.Add(jogador); // adiciona ao arraylist "jogadores", contido na classe "Time", os valores do objeto "jogador"
                            }//fim da repetição
                        }
                        else //se não 
                        {
                            AlterarRemover(); //retorna para o início do módulo "AlterarRemover"
                        }
                    }
                    count++; // incrementa a variável "count"
                }//fim da repetição
                if (!encontrado) // caso a variável booleana "encontrado" contenha o valor falso
                {
                    Console.Clear(); // limpará o console

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|\t    ALTERAR TIME\tCBLOL\t\t     |");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|----------------------------------------------------|");

                    Console.WriteLine("|\n|\n| Item {0} não existe!", nome); //exibirá que o time solicitado para alteração não existe
                    Console.WriteLine("|\n|\n| Escolha a opção:");
                    Console.WriteLine("|\n| 1-Voltar a Alterar ou Remover \n| 2-Ir ao Menu incial"); // exibe opções para o usuário caso o time não exista 
                    Console.Write("|\n| Insira a Opção:");
                    opcao = Console.ReadLine(); // atribui à variável "opcao" o valor digitado pelo usuário
                    if (opcao == "1") //se o digitado for igual a 1, então
                    {
                        AlterarRemover(); //volta para o início do módulo "AlterarRemover" 
                    }
                    else if (opcao == "2") //se o digitado for igual a 2, então
                    {
                        Escolher(); //volta para o início do módulo "Escolher"
                    }
                }
                else //se não 
                {
                    times[countAlterar] = time1; //salva o contido no objeto "time1" no arraylist "times"
                }
                if (File.Exists(ficheiro))// se o arquivo "ficheiro" existe, então
                {
                    file = new StreamWriter(ficheiro); //escreverá no arquivo o listado a seguir
                    foreach (Time time in times) // lê todo o arraylist "times"
                    {
                        linha = time.nome + "|"; //capturando cada elemento "time" contido nele e atribuindo à variável "linha" somada a uma barra reta 
                        foreach (Jogador jogador in time.jogadores) // lê todo o arraylist "jogadores", que está contido na classe "time"
                        {
                            linha += jogador.nome + "|" + jogador.posicao + "|"; //insere o contido no arraylist "jogadores" na variável "linha"
                        }
                        file.WriteLine(linha); // escreve o contido na variável "linha" no arquivo "ficheiro"
                    }
                    file.Close(); //encerra a execução do arquivo "ficheiro"
                }
                else // se não
                {
                    file = File.CreateText(ficheiro); // cria o arquivo "ficheiro"
                }
                Console.Clear(); // limpa o console

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    ALTERAR TIME\tCBLOL\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|\n| Time alterado com sucesso!"); // exibe ao usuário que a alteração foi feita com sucesso
                Console.WriteLine("|\n|\n| Escolha a opção:");
                Console.WriteLine("|\n| 1-Voltar a Alterar ou Remover \n| 2-Ir ao Menu incial"); // e mostra as opções que ele tem para continuar executando o programa
                Console.Write("|\n| Insira a Opção:");
                opcao = Console.ReadLine(); // atribui à variável "opcao" o valor digitado pelo usuário
                if (opcao == "1") // se o valor atribuído for igual a 1, então
                {
                    AlterarRemover(); // voltará ao início do módulo "AlterarRemover"
                }
                else if (opcao == "2") //se o valor atribuído for igual a 2, então
                {
                    Escolher(); //volta ao início do módulo "Escolher"
                }
            }
            else if (opcao == "2") //se o valor atribuído for igual a 2, então
            {
                Console.Clear(); // limpa o console

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    REMOVER TIME\tCBLOL\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("| Insira o nome do time que quer deletar:"); // solicita ao usuário o time que ele quer deletar
                string nome = Console.ReadLine(); // declara a variável "nome" e atribui a ela o valor digitado pelo usuário
                bool encontrado = false; //declara uma variável booleana e atribui a ela o valor "false"
                string linha; // declara a variável "linha"
                foreach (Time time in times) // lê todo o contido no arraylist "times"
                {
                    if (time.nome.ToLower().Contains(nome.ToLower())) // se o valor na posição atual da leitura do arraylist, convertido para minúsculo, 
                                                                      //contiver o digitado pelo usuário, convertido para minúsculo, então
                    {
                        encontrado = true; // a variável booleana receberá o valor true

                        Console.Clear(); // limpa o console

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t    REMOVER TIME\tCBLOL\t\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");

                        Console.WriteLine("| O time {0} existe e pode ser removido.", time.nome); // exibe para o usuário que o time digitado existe
                        Console.WriteLine("|\n| Deseja remover o time {0}? s p/ sim", time.nome);// e pergunta se ele deseja realmente removê-lo
                        if (Console.ReadLine().ToLower() == "s") //se a resposta for "S", então
                        {

                            times.Remove(time); // removerá o "time" do arraylist "times"
                            break; // encerra a execução do foreach
                        }
                    }

                }//fim da repetição
                if (!encontrado) //se a variável booleana ainda contiver o valor false após o foreach, então
                {
                    Console.Clear(); // limpa o console

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|\t    REMOVER TIME\tCBLOL\t\t     |");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|----------------------------------------------------|");

                    Console.WriteLine("|\n|\n| Item {0} não existe!", nome); //exibirá que o time não existe
                    Console.WriteLine("|\n|\n| Escolha a opção:");
                    Console.WriteLine("|\n| 1-Voltar a Alterar ou Remover \n| 2-Ir ao Menu incial"); // e exibirá as opções possíveis para o usuário seguir operando o sistema
                    Console.Write("|\n| Insira a Opção:");
                    opcao = Console.ReadLine();// atribui à variável "opcao" o valor digitado pelo usuário
                    if (opcao == "1") // se o valor atribuído for igual a 1, então
                    {
                        AlterarRemover(); // voltará ao início do módulo "AlterarRemover"
                    }
                    else if (opcao == "2") //se o valor atribuído for igual a 2, então
                    {
                        Escolher(); //volta ao início do módulo "Escolher"
                    }
                }
                if (File.Exists(ficheiro)) // se o arquivo ficheiro existe, então
                {
                    file = new StreamWriter(ficheiro);//escreverá no arquivo o listado a seguir
                    foreach (Time time in times) // lê todo o arraylist "times"
                    {
                        linha = time.nome + "|";  //capturando cada elemento "time" contido nele e atribuindo à variável linha somada a uma barra reta 
                        foreach (Jogador jogador in time.jogadores) // lê todo o arraylist "jogadores" que está contido na classe "time"
                        {
                            linha += jogador.nome + "|" + jogador.posicao + "|"; //insere o contido no arraylist "jogadores" na variável "linha"
                        }
                        file.WriteLine(linha); // escreve o contido na variável "linha" no arquivo "ficheiro"
                    } //fim da repetição
                    file.Close();//encera a execução do arquivo "ficheiro"
                }
                else // se não
                {
                    file = File.CreateText(ficheiro); // cria o arquivo "ficheiro"
                }
                Console.Clear(); // limpa o console

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t    REMOVER TIME\tCBLOL\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("|\n|\n| Time removido com sucesso!"); // exibe que o time foi removido com sucesso
                Console.WriteLine("|\n|\n| Escolha a opção:");
                Console.WriteLine("|\n| 1-Voltar a Alterar ou Remover \n| 2-Ir ao Menu incial"); // e exibe as opções do usuário para continuar operando o sistema
                Console.Write("|\n| Insira a Opção:");
                opcao = Console.ReadLine(); // atribui à variável "opcao" o valor digitado pelo usuário
                if (opcao == "1") // se o valor atribuído for igual a 1, então
                {
                    AlterarRemover(); // voltará ao início do módulo "AlterarRemover"
                }
                else if (opcao == "2") //se o valor atribuído for igual a 2, então
                {
                    Escolher(); //volta ao início do módulo "Escolher"
                }
            }
            else if (opcao == "3") // se o valor atribuído for igual a 3, então
            {
                Escolher();  // voltará ao início do módulo "Escolher"
            }

        }
        //---------------------------------------------
        // 5 - CONSULTAR TIMES E JOGADORES JÁ INSERIDOS
        //---------------------------------------------
        static void Consultar() //declara o módulo "Consultar"
        {
            Console.Clear(); // limpa a tela

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|\t   CONSULTA\t\tCBLOL\t\t     |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");

            Console.WriteLine("| Insira o time ou jogador que deseja consultar:     |"); // solicita ao usuário que insira o time ou o jogador a ser consultado
            string nome = Console.ReadLine(); // declara a variável "nome" e atribui o valor digitado pelo usuário a ela 
            bool encontrado = false; // declara uma variável e atribui a ela o valor false
            foreach (Time time in times) // lê todo o contido no arraylist "times"
            {
                if (time.nome.ToLower().Contains(nome.ToLower()))  // se o valor na posição atual da leitura, convertido para minúsculo, 
                                                                   // contiver o digitado pelo usuário, convertido para minúsculo, então
                {
                    encontrado = true; // a variável booleana receberá true

                    Console.Clear(); // limpa a tela

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|\t   CONSULTA\t\tCBLOL\t\t     |");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|----------------------------------------------------|\n");
                    Console.WriteLine("  {0} foi encontrado no banco de dados.\n", time.nome); // exibe que a consulta foi bem sucedida
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|\tTime        Jogadores\t      Posições\t     |");
                    Console.WriteLine("|----------------------------------------------------|");

                    foreach (Jogador jogador in time.jogadores) // lê todo o conteúdo no arraylist "jogadores", contido na classe "Time"
                    {
                        Console.WriteLine("     {0}       {1}\t\t{2}", time.nome, jogador.nome, jogador.posicao); // exibe o nome do jogador na posição atual
                    }
                    Console.WriteLine(" ---------------------------------------------------- ");
                    Console.WriteLine(" \n \n  Escolha a opção:");
                    Console.WriteLine(" \n  1-Voltar p/Consultar \n  2-Ir ao Menu incial"); // e mostra as opções possíveis para o usuário seguir operando o sistema
                    Console.Write(" \n  Insira a Opção:");
                    string opcao = Console.ReadLine(); // declara a variável "opcao" e atribui o valor digitado pelo usuário a ela
                    if (opcao == "1") // se o valor atribuído for igual a 1, então
                    {
                        Consultar(); // encaminha o usuário para o início do módulo "Consultar"
                    }
                    else if (opcao == "2") // se o valor atribuído for igual a 2, então
                    {
                        Escolher(); // encaminha o usuário para o módulo "Escolher"
                    }
                    Console.ReadKey(); // espera o click do usuário em qualquer tecla para seguir executando o código
                }
                foreach (Jogador jogador in time.jogadores) // lê todo o conteúdo no arraylist "jogadores", contido na classe "Time"
                {
                    if (jogador.nome.ToLower().Contains(nome.ToLower())) // compara o valor dado pelo usuário à variável "nome" com o texto existente
                                                                         // na posição atual do arraylist "jogadores" que o foreach está lendo
                    {
                        encontrado = true; // caso válida a comparação, a variável booleana receberá true como valor
                        Console.Clear(); // limpa a tela

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|\t   CONSULTA\t\tCBLOL\t\t     |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("| Jogador Encontrado.");
                        Console.WriteLine("|\n| Jogador: {0}\n| Jogando na poisição: {1}", jogador.nome, jogador.posicao); // exibe na tela o jogador encontrado na busca e sua posição
                        Console.WriteLine("|\n|\n| Escolha a opção:");
                        Console.WriteLine("|\n| 1-Voltar p/Consultar \n| 2-Ir ao Menu incial"); // e mostra as opções possíveis para o usuário seguir operando o sistema
                        Console.Write("|\n| Insira a Opção:");
                        string opcao = Console.ReadLine(); // declara a variável "opcao" e atribui o valor digitado pelo usuário a ela
                        if (opcao == "1") // se o valor atribuído for igual a 1, então
                        {
                            Consultar(); // encaminha o usuário para o início do módulo "Consultar"
                        }
                        else if (opcao == "2") // se o valor atribuído for igual a 2, então
                        {
                            Escolher(); // encaminha o usuário para o módulo ""Escolher"
                        }
                    }
                }
            }
            if (!encontrado) // caso o valor da variável booleana se mantenha em false
            {
                Console.Clear(); // limpa a tela

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|\t   CONSULTA\t\tCBLOL\t\t     |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("|\n| {0} não existe no banco de dados.", nome); // exibe no console que não foi possível encontrar o item buscado
                Console.WriteLine("|\n|\n|\n| Escolha a opção:");
                Console.WriteLine("|\n| 1-Voltar p/Consultar \n| 2-Ir ao Menu incial"); // e mostra as opções possíveis para o usuário seguir operando o sistema
                Console.WriteLine("|");
                Console.Write("| Insira a Opção:");
                string opcao = Console.ReadLine(); // declara a variável "opcao" e atribui o valor digitado pelo usuário a ela
                if (opcao == "1") // se o valor atribuído for igual a 1, então
                {
                    Consultar(); // encaminha o usuário para o início do módulo "Consultar"
                }
                else if (opcao == "2") // se o valor atribuído for igual a 2, então
                {
                    Escolher(); // encaminha o usuário para o módulo "Escolher"
                }
            }
        }
        //-------------------------------------------------
        // 6 - LISTAR TIMES/JOGADORES/POSIÇÕES JÁ INSERIDOS
        //-------------------------------------------------
        static void Listar() // cria o metódo "Listar"
        {
            Console.Clear(); // limpa o console

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|\t\tTIMES\t\tCBLOL\t\t     |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|\tTime        Jogadores\t      Posições\t     |");
            Console.WriteLine("|----------------------------------------------------|");

            //EXIBINDO OS DADOS CARREGADOS DO FICHEIRO
            foreach (Time time in times) // lê todo o conteúdo no arraylist "times"
            {
                foreach (Jogador jogador in time.jogadores)  // lê todo o conteúdo no arraylist "times"
                {
                    Console.WriteLine("|    {0}       {1}\t\t{2}", time.nome, jogador.nome, jogador.posicao); // exibe tudo que está armazenado nas posições atuais do arraylist que corespondem a essas variáveis 
                }
                Console.WriteLine("                                                      ");
                Console.WriteLine("|----------------------------------------------------|");
            }
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| Aperte qualquer tecla para voltar ao menu inicial. |"); //diz ao usuário o que ele deve fazer para voltar à tela inicial do menu "Escolher"
            Console.WriteLine("|----------------------------------------------------|");
            Console.ReadKey();
        }
    }
}