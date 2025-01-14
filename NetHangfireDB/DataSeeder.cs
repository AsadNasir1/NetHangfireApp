using NetHangfireDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHangfireDB
{
    public class DatabaseSeeder
    {
        private readonly NetHangfireDBContext _context;

        public DatabaseSeeder(NetHangfireDBContext context)
        {
            _context = context;
        }

        public void SeedTestData()
        {
            if (_context.Movies.Any()) return; // Avoid duplicate seed

            //_context.Movies.AddRange(
            //    new Movie { Title = "Inception", ReleaseYear = "2010", Poster = "https://www.bing.com/ck/a?!&&p=6df9fc2f4dc8d9dfb69c92d4baabb5ee74775692b5d65bfb6451b821ef76b702JmltdHM9MTczNjgxMjgwMA&ptn=3&ver=2&hsh=4&fclid=237e96e3-2e7e-6904-1469-85e22f7768a4&u=a1L2ltYWdlcy9zZWFyY2g_cT1pbmNlcHRpb24lMjB0aXRsZSUyMHBpY3R1cmUlMjBsaW5rJkZPUk09SVFGUkJBJmlkPUNGRENBRkFEMjlGM0FBRUI0QTRGOTUwQjhEQzg1NjRFQjMwMTM1NUE&ntb=1" },
            //    new Movie { Title = "The Matrix", ReleaseYear = "1999", Poster = "https://th.bing.com/th?id=OIP.F893mtomcag1M_1YGRALrwHaEK&w=333&h=187&c=8&rs=1&qlt=90&o=6&dpr=1.6&pid=3.1&rm=2" },
            //    new Movie { Title = "Interstellar", ReleaseYear = "2014", Poster = "https://www.bing.com/th?id=OIP.Bwvvxi550VUCRMmtE-TN7wHaEK&w=149&h=100&c=8&rs=1&qlt=90&o=6&dpr=1.6&pid=3.1&rm=2" },
            //    new Movie { Title = "Spider-Man: No Way Home", ReleaseYear = "2021", Poster = "https://www.bing.com/ck/a?!&&p=3aebb6cc0b1af9f657f35d9d0e3c961b56e61fc4aae7d2e1ee4a56d709cb568eJmltdHM9MTczNjgxMjgwMA&ptn=3&ver=2&hsh=4&fclid=237e96e3-2e7e-6904-1469-85e22f7768a4&u=a1L2ltYWdlcy9zZWFyY2g_cT1zcGlkZXItbWFuK25vK3dheStob21lKzIwMjEmaWQ9MzUyRUFENjZEQjQ2OTlERjJCNDdCOTcyNzgwOTU4Njc0RDQxRjk3Mg&ntb=1" },
            //    new Movie { Title = "Spider-Man: Homecoming", ReleaseYear = "2017", Poster = "https://www.bing.com/th?id=OIP.ztjFBG7xvkj3aYUQrS4zzAHaLH&w=155&h=200&c=8&rs=1&qlt=90&o=6&dpr=1.6&pid=3.1&rm=2" }
            //);

            _context.Movies.AddRange(
                new Movie { Title = "Inception", ReleaseYear = "2010", Poster = "https://i0.wp.com/images.onwardstate.com/uploads/2010/10/inception.png?fit=1593%2C947&ssl=1" },
                new Movie { Title = "The Matrix", ReleaseYear = "1999", Poster = "https://shatpod.com/movies/wp-content/uploads/The-Matrix-1999-Movie-Poster-720x340.jpg" },
                new Movie { Title = "Interstellar", ReleaseYear = "2014", Poster = "https://rukminim2.flixcart.com/image/850/1000/xif0q/poster/4/z/x/small-spos8585-poster-movie-interstellar-wall-poster-sl-8585-original-imaghzwa4c7zahsz.jpeg?q=90&crop=false" },
                new Movie { Title = "Spider-Man: No Way Home", ReleaseYear = "2021", Poster = "https://www.comingsoon.net/wp-content/uploads/sites/3/gallery/spider-man-no-way-home-posters/spider-man-no-way-home-poster-2.jpg" },
                new Movie { Title = "Spider-Man: Homecoming", ReleaseYear = "2017", Poster = "https://rukminim2.flixcart.com/image/850/1000/l01blow0/poster/8/i/x/medium-spider-man-homecoming-concept-on-fine-art-paper-hd-original-imagbx2qegf9ehma.jpeg?q=90&crop=false" }
            );

            _context.SaveChanges();
        }
    }
}
