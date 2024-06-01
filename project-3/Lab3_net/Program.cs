using ExcelLib;
using WordLib;

namespace Lab3_net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = $"{Directory.GetCurrentDirectory()}\\Shop.json"; // Змініть шлях до файлу відповідно до вашого середовища
            ShopData shopData = JSONservice.ReadData(filePath);

            List<Game> games = shopData.GetGames;
            List<User> users = shopData.GetUsers;
            using (var x = new ExcelDocument())
        {
                var gamesSheet = x.AddSheet("Games");

                // Headers
                gamesSheet.Cells[1, 1] = "ID";
                gamesSheet.Cells[1, 2] = "Name";
                gamesSheet.Cells[1, 3] = "Publisher";
                gamesSheet.Cells[1, 4] = "Price";
                gamesSheet.Cells[1, 5] = "Rating";

                // Data
                for (int i = 0; i < games.Count; i++)
                {
                    gamesSheet.Cells[i + 2, 1] = games[i].id;
                    gamesSheet.Cells[i + 2, 2] = games[i].Name;
                    gamesSheet.Cells[i + 2, 3] = games[i].Publisher;
                    gamesSheet.Cells[i + 2, 4] = games[i].Price;
                    gamesSheet.Cells[i + 2, 5] = games[i].Rating;
                }
                var usersSheet = x.AddSheet("Users");

                // Headers
                usersSheet.Cells[1, 1] = "Username";
                usersSheet.Cells[1, 2] = "Firstname";
                usersSheet.Cells[1, 3] = "Lastname";
                usersSheet.Cells[1, 4] = "Balance";

                // Data
                for (int i = 0; i < users.Count; i++)
                {
                    usersSheet.Cells[i + 2, 1] = users[i].Username;
                    usersSheet.Cells[i + 2, 2] = users[i].Firstname;
                    usersSheet.Cells[i + 2, 3] = users[i].Lastname;
                    usersSheet.Cells[i + 2, 4] = users[i].Balance;

                    if (users[i].Library != null && users[i].Library.Game != null)
                    {
                        for (int j = 0; j < users[i].Library.Game.Count; j++)
                        {
                            usersSheet.Cells[i + 2, 5 + j] = users[i].Library.Game[j].Name;
                        }
                    }
                }
                string filename = $"{Directory.GetCurrentDirectory()}\\testdoc.xlsx";
                x.SaveAs(filename);
            }
            using (var doc = new WordDocument())
            {
                List<string[]> rows1 = new List<string[]>
        {
            new string[] { "ID", "Name", "Publisher", "Price", "Rating" }
        };

                foreach (var game in games)
                {
                    rows1.Add(new string[]
                    {
                game.id.ToString(),
                game.Name,
                game.Publisher,
                game.Price.ToString(),
                game.Rating.ToString()
                    });
                }
                doc.AddTable("Games", rows1);
                List<string[]> rows = new List<string[]>
        {
            new string[] { "Username", "Firstname", "Lastname", "Balance" }
        };

                foreach (var user in users)
                {
                    rows.Add(new string[]
                    {
                user.Username,
                user.Firstname,
                user.Lastname,
                user.Balance.ToString()
                    });
                }

                doc.AddTable("Users", rows);
                string filename = $"{Directory.GetCurrentDirectory()}\\testdoc.docx";
                doc.SaveAs(filename);
            }
        }        
    }
}