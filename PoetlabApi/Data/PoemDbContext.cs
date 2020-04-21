using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoetlabApi.Data.Mappers;
using PoetlabApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Data
{
    public class PoemDbContext : IdentityDbContext
    {
        public DbSet<Poem> Poems { get; set; }
        public DbSet<UserModel> UserModel { get; set; }

        public PoemDbContext(DbContextOptions options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PoemConfiguration());
            modelBuilder.ApplyConfiguration(new UserModelConfiguration());

            modelBuilder.Entity<Poem>().HasData(
                new Poem
                {
                    Id = 6,
                    Title = "A Jelly-Fish",
                    Author = "Ismael",
                    PoemText = "Visible, invisible,\n" +
                    "A fluctuating charm,\n" +
                    "An amber - colored amethyst\n" +
                    "Inhabits it; your arm\n" +
                    "Approaches, and\n" +
                    "It opens and\n" +
                    "It closes;\n" +
                    "You have meant\n" +
                    "To catch it,\n" +
                    "And it shrivels;\n" +
                    "You abandon\n" +
                    "Your intent—\n" +
                    "It opens, and it\n" +
                    "Closes and you\n" +
                    "Reach for it—\n" +
                    "The blue\n" +
                    "Surrounding it\n" +
                    "Grows cloudy, and\n" +
                    "It floats away\n" +
                    "From you.",
                    Themes = new string[] { "Oceans", "War" },
                    UpVoters = new List<string>(),
                    DownVoters = new List<string>(),
                    Date = new DateTime(2015, 8, 30)
                },
                new Poem
                {
                    Id = 7,
                    Title = "The Imaginal Stage",
                    Author = "Ismael",
                    PoemText = "turns out\n" +
                    "there are more planets than stars\n" +
                    "more places to land\n" +
                    "than to be burned\n" +
                    "I have always been in love with\n" +
                    "last chances especially\n" +
                    "now that they really do\n" +
                    "seem like last chances\n" +
                    "the trill of it all upending\n" +
                    "what’s left of my head\n" +
                    "after we explode\n" +
                    "are you ready to ascend\n" +
                    "in the morning I will take you\n" +
                    "on the wing",
                    Themes = new string[] { "Love" },
                    UpVoters = new List<string>(),
                    DownVoters = new List<string>(),
                    Date = new DateTime(2019, 3, 28)
                }, new Poem {
                    Id = 1,
                    Title = "All Entire",
                    Author = "web4",
                    PoemText = "The Demon, in my lofty vault,\nThis morning came to visit me,\nAnd striving me to find at fault,\nHe said, \"Fain would I know of thee;\n\n\"Among the many beauteous things,\n—All which her subtle grace proclaim—\nAmong the dark and rosy things,\nWhich go to make her charming frame,\n\n\"Which is the sweetest unto thee\"?\nMy soul! to Him thou didst retort—\n\"Since all with her is destiny,\nOf preference there can be nought.\n\nWhen all transports me with delight,\nIf aught deludes I can not know,\nShe either lulls one like the Night,\nOr dazzles like the Morning-glow.\n\nThat harmony is too divine,\nWhich governs all her body fair,\nFor powerless mortals to define\nIn notes the many concords there.\n\nO mystic metamorphosis\nOf all my senses blent in one!\nHer voice a beauteous perfume is,\nHer breath makes music, chaste and wan.",
                    Themes = new string[] { "Afterlife", "Demon", "Myth" },
                    UpVoters = new List<string> { "web4", "ismael" },
                    DownVoters = new List<string> (),
                    Date = new DateTime(2019, 5, 24),
                    Upvotes = 2,
                    Downvotes = 0,
                    Image = null
                }, new Poem {
                    Id = 2,
                    Title = "Ill Luck",
                    Author = "web4",
                    PoemText = "This heavy burden to uplift,\nO Sysiphus, thy pluck is required!\nAnd even though the heart aspired,\nArt is long and Time is swift.\n\nAfar from sepulchres renowned,\nTo a graveyard, quite apart,\nLike a broken drum, my heart,\nBeats the funeral marches' sound.\n\nMany a buried jewel sleeps\nIn the long-forgotten deeps,\nFar from mattock and from sound;\n\nMany a flower wafts aloft\nIts perfumes, like a secret soft,\nWithin the solitudes, profound",
                    Themes = new string[] { "Illness", "Luck" },
                    UpVoters = new List<string> { "ismael" },
                    DownVoters = new List<string> { "web4" },
                    Date = new DateTime(2018, 8, 12),
                    Upvotes = 1,
                    Downvotes = 1,
                    Image = null
                }, new Poem {
                    Id = 3,
                    Title = "Contemplation",
                    Author = "web4",
                    PoemText = "THOU, O my Grief, be wise and tranquil still,\nThe eve is thine which even now drops down,\nTo carry peace or care to human will,\nAnd in a misty veil enfolds the town.\n \nWhile the vile mortals of the multitude,\nBy pleasure, cruel tormentor, goaded on,\nGather remorseful blossoms in light mood--\nGrief, place thy hand in mine, let us be gone\n \nFar from them. Lo, see how the vanished years,\nIn robes outworn lean over heaven's rim;\nAnd from the water, smiling through her tears,\n \nRemorse arises, and the sun grows dim;\nAnd in the east, her long shroud trailing light,\nList, O my grief, the gentle steps of Night.",
                    Themes = new string[] { "Love", "Luck" },
                    UpVoters = new List<string>(),
                    DownVoters = new List<string> { "web4", "ismael" },
                    Date = new DateTime(2019, 1, 17),
                    Upvotes = 0,
                    Downvotes = 2,
                    Image = null
                }, new Poem {
                    Id = 4,
                    Title = "The Giantess",
                    Author = "ismael",
                    PoemText = "I should have loved—erewhile when Heaven conceived\nEach day, some child abnormal and obscene,\nBeside a maiden giantess to have lived,\nLike a luxurious cat at the feet of a queen;\n\nTo see her body flowering with her soul,\nAnd grow, unchained, in awe-inspiring art,\nWithin the mists across her eyes that stole\nTo divine the fires entombed within her heart.\n\nAnd oft to scramble o'er her mighty limbs,\nAnd climb the slopes of her enormous knees,\nOr in summer when the scorching sunlight streams\n\nAcross the country, to recline at ease,\nAnd slumber in the shadow of her breast\nLike an hamlet 'neath the mountain-crest.",
                    Themes = new string[] { "Flowers", "Love", "Myth" },
                    UpVoters = new List<string> { "ismael", "web4"},
                    DownVoters = new List<string> (),
                    Date = new DateTime(2018, 12, 22),
                    Upvotes = 2,
                    Downvotes = 0,
                    Image = null
                }, new Poem {
                    Id = 5,
                    Title = "Man and the Sea",
                    Author = "ismael",
                    PoemText = "Free man! the sea is to thee ever dear!\nThe sea is thy mirror, thou regardest thy soul\nIn its mighteous waves that unendingly roll,\nAnd thy spirit is yet not a chasm less drear.\n\nThou delight'st to plunge deep in thine image down;\nThou tak'st it with eyes and with arms in embrace,\nAnd at times thine own inward voice would'st efface\nWith the sound of its savage ungovernable moan.\n\nYou are both of you, sombre, secretive and deep:\nOh mortal, thy depths are foraye unexplored,\nOh sea—no one knoweth thy dazzling hoard,\nYou both are so jealous your secrets to keep!\n\nAnd endless ages have wandered by,\nYet still without pity or mercy you fight,\nSo mighty in plunder and death your delight:\nOh wrestlers! so constant in enmity!",
                    Themes = new string[] { "Desire", "Landscapes", "Oceans" },
                    UpVoters = new List<string>{"ismael"},
                    DownVoters = new List<string> { "web4" },
                    Date = new DateTime(2018, 10, 1),
                    Upvotes = 1,
                    Downvotes = 1, 
                    Image = null}
              );
        }
    }
}
