using UnityEngine;
using System.Collections;

/// <summary>
/// Initial author - Liam M
/// </summary>

public static partial class ApocalypseConstants
{
#region Apocalypses

	// Famine is the basic apocalypse. Every other one will be based on this format
	#region Famine

	// The following variables contain all the text displayed.
	public const string FAMINE_APOCALYPSE_STRING = "Famine";
	public const string FAMINE_INTRO_TEXT0 = "The world now faces a famine of global proportions. " +
		"Food is growing more scarce by the day. Starvation and disease are rampant.";
	public const string FAMINE_INTRO_TEXT1 = "A necrotic disease has caused decaying plant matter to become a toxin to the earth. " +
		"Containment has failed. Starvation is imminent.";
	public const string FAMINE_MAIN_TEXT0 = "Famine never starts off fast. It’s always a small little incident that seems easy to treat. This one wasn’t." +
		"\n\nIt was very selective at first. A few prominent crops were really starting to have trouble growing. Wheat and corn mostly; the cornerstone crops " +
		"that everyone just expects to be able to grow everywhere. However, the fields continued to produce fewer and fewer crops over time, and the fields shrank. " +
		"This was not a standard plant life issue, however. The plants that died did not just wither, but decayed into a form of necrotic poison. They would actively " +
		"absorb nutrients and water from the surrounding area, killing anything within their reach. Removing the plants slowed the process, but the necrotic roots " +
		"would cause in a serious illness for those who tried. No one wanted to go near the plants, and it was thought best just to let the crops die and replant." +
		"\n\nHowever, humanity forgot about something: insects. They would feed on the crops and slowly die from the poison. When they fell, their bodies became a new " +
		"source for the disease. Bees were the worst. They would seek to pollinate flowers and plants as usual. Any plant already infected would still produce pollen " +
		"for a short time, allowing the bees to extract what they needed and carry the contagion throughout the fields. Before anyone could stop them, the necrosis was " +
		"wiping out acres of land. Pesticides would only stop the bugs from feeding on the plants, but nothing could actively kill a disease born of death." +
		"\n\nAlternatives have been proposed, tested, thrown out, and rethought. Soon, there will be no options left…";
	public const string FAMINE_MAIN_TEXT1 = "Famine never hits fast. It’s a slow, inevitable crawl towards starvation. But this one wasn’t local.\n\n" +
		"It was selective at first. Isolated farms filled with staple crops like corn and wheat began to show signs of depletion. But crop rotation didn’t seem to help, " +
		"and soon the problem become more potent. The plants that died did not just wither, but became a form of necrotic toxin. They would actively absorb nutrients and " +
		"water from the surrounding area, killing anything and everything they could reach. Removing the plants slowed the process, but the poisoned roots would cause " +
		"necrosis in anyone who touched them. Soon, no one wanted to go near the infected farms. They thought the problem could be quarantined, and waited out. They were " +
		"wrong. \n\nInsects began to feed on the dead plant matter, and were killed as a result. Their bodies became a new source for the disease, and quickly spread it far " +
		"outside the quarantined zones. Bees carried contaminated pollen to healthy plants. Before anyone could move to contain the problem, it had become a global epidemic. " +
		"Nothing could actively kill a disease borne by decay.\n\nWith cornerstone crops depleted, demand for hunting and fishing grew. Soon, the easy prey was nearly wiped " +
		"out thanks to mass panic as people tried to stock up on meats. Lakes and rivers were emptied of their fish, and the oceans were filled with boats competing for space. " +
		"\n\nIt took merely a few years for the effects to be felt worldwide from the time the contagion began. Any home gardens that were spared the necrosis could only " +
		"provide enough to feed that immediate family. Farms were already bought and sold, and and ranches emptied of their livestock. Any plans that local governments have " +
		"tried have already failed. Now, options run slim…";
	public const string FAMINE_SUCCESS_TEXT = "You’ve managed to survive the global famine. As the disease abates, you realize a new task awaits the survivors: burying " +
		"their dead and mourning for those who did not survive. For those who lived, your fragile alliance still holds. But new dangers still await. As the days pass, " +
		"the living must turn their backs on the past, and turn to face their uncertain futures.";
	public const string FAMINE_FAILURE_TEXT = "The famine proved to be too formidable, even for some of the strongest countries on Earth. The necrosis sapped the land " +
		"of all its resources, stripping away what was once a thriving ecosystem. As supplies depleted, so did hope. It was not long before anarchy broke out amongst " +
		"the rapidly declining population, and your alliance dissolved amidst blood and flames. Those few who survived must seek new homes, lest the now-ravaged land take their lives as well.";
    public const string FAMINE_SOLVE_BUTTON_0_TEXT = "Research Cure (Sci -90, Econ: -40)";
    public const string FAMINE_SOLVE_BUTTON_1_TEXT = "Martial Law (Mili -70)";
	// These constants will govern how Famine affects your stats every turn.
	public const int FAMINE_POPULATION_REDUCTION = 100;
	public const int FAMINE_SCIENCE_REDUCTION = 50;
	public const int FAMINE_ECONOMY_REDUCTION = 40;

	// These constants will allow you to solve Famine
	// This first set will allow you to cure the disease with enough investment of science and money. It is more difficult, but will lose you less people.
	public const int FAMINE_SCIENCE_SOLVE = 90;
	public const int FAMINE_ECONOMY_SOLVE = 40;

	// This will let you set up martial safe zones. Many will die, but your people will survive.
	public const int FAMINE_MILITARY_SOLVE = 100;
    public const int FAMINE_POPULATION_SOLVE = 30;
	#endregion

// Zombies are classic, amirite?
	#region Zombies

	// The following variables contain all the text displayed.
	public const string ZOMBIES_APOCALYPSE_STRING = "Zombies";
	public const string ZOMBIES_INTRO_TEXT0 = "The Earth has is being ravaged by an other-worldly scourge. Death no longer grants rest to those who pass through her gates. " +
		"Powerful epidemic or ancient curse, it doesn’t matter now. What matters is survival.";
	public const string ZOMBIES_INTRO_TEXT1 = "What happens when death is no longer a final goodbye? The corpses of the damned now walk the Earth with no respite, " + 
		"hungry shells of what were once people. Cure, containment, or extermination. Regardless of the means, the end must be the same. Stop the spread before it’s too late.";
	public const string ZOMBIES_MAIN_TEXT0 = "The spread of this contagion has been a sobering affair. Tens of thousands of people were killed and reanimated within the first " +
		"two weeks of its public appearance, and now the virus is steadily making its way to every corner of the globe. \n\n Research is being conducted, though it has so far " +
		"remained inconclusive. Further testing needs to be done in order to classify and attempt to cure the virus, but the hope of this option remaining viable dwindles daily. "+
		"As more people turn, the still-living population is becoming desperate for answers. And desperation, as we all know, breeds panic. \n\nOptions are limited and time is " +
		"short. Decisive action is required. Perhaps now more than ever.";
	public const string ZOMBIES_MAIN_TEXT1 = "“It was right out of a damn horror film. It had everything. A patient zero, a government response, a horde of “safe houses”, " +
		"and group of idiots who thought they had prepared for it. Disease transferred by a bite, blood contact, who really cares? They’re here, and the situation is growing " +
		"worse. It’s not about bites anymore. It’s reached the point where newborns are taking their first breath as one of the damn things. \n\nWhat were we supposed to do? " +
		"Let the creatures just keep coming? We had to find a way to stop it. And no mercy, no leeway, and no remorse would help with that. \n\nHunting parties to corral the " +
		"monsters, doctors to identify and act on the unborn. Gruesome but effective. Yet it’s all just a delay. We won’t be able to stop them forever.” " +
		"\n\n -From a note, found with the corpse of a former soldier.";
	public const string ZOMBIES_SUCCESS_TEXT = "Despite all odds, humanity manages to survive another day. Through your guiding hand, the survivors were able to hold out past the " +
		"threat. The path wasn’t easy, but the road ahead will be even less so.";
	public const string ZOMBIES_FAILURE_TEXT = "Whatever it was that possessed the shambling corpses, you were unable to overcome their sheer numbers. Luck, time, and fate were not " +
		"on your side. As the population was consumed by the undead, order simply melted away. An alliance cannot be forged between two dead men.";
    public const string ZOMBIES_SOLVE_BUTTON_0_TEXT = "Research Cure (Sci -90 Econ -60)";
    public const string ZOMBIES_SOLVE_BUTTON_1_TEXT = "Extinction (Mili -200)";

    // These constants will govern how Zombies affects your stats every turn. This is a highly detrimental apocalypse.
    public const int ZOMBIES_POPULATION_REDUCTION = 80;
	public const int ZOMBIES_RELIGION_REDUCTION = 20;
	public const int ZOMBIES_ECONOMY_REDUCTION = 50;
	public const int ZOMBIES_MILITARY_REDUCTION = 40;

	// These constants will allow you to solve Zombies
	// This first set will allow you to solve zombies by trying to find a cure. May take longer, but your reputation will greatly improve.
	public const int ZOMBIES_SCIENCE_SOLVE = 90;
	public const int ZOMBIES_ECONOMY_SOLVE = 60;

	// This will let you set up military encampments, and exterminate outsiders. Many will die, but it is decisive.
	public const int ZOMBIES_MILITARY_SOLVE = 200;
	#endregion

// Angels is the major religion-based apocalypse
	#region Angels

	// The following variables contain all the text displayed.
	public const string ANGELS_APOCALYPSE_STRING = "Divine Retribution";
	public const string ANGELS_INTRO_TEXT0 = "When the gates of heaven open, it will not be to spread peace. It will be when god is so troubled by His creation " +
		"that he sees no alternative but to baptize the world in blood and fire.";
	public const string ANGELS_INTRO_TEXT1 = "The new threat does not come within, but from above. God’s wrathful army has come, and it is not to judge humanity. " + 
		"It is to purge all living things, and eliminate sin from the Earth.";
	public const string ANGELS_MAIN_TEXT0 = "“Prayers are a funny thing. People just keep making them like firing buckshot in a prairie. Eventually one would hit, right?" +
		"\n\n“I remember the day all the organized religions’ holy ones began spouting their usual nonsense about the end times. Except this time they weren’t saying " + 
		"repent and be saved like normal. No... they were telling everyone that we’re all fucked. \n\n“You don’t need to understand that a divine will is not impacting " +
		"your life. But science can’t explain how the sun could burn out and still leave our planet standing, like it was nothing more than the largest light bulb you’ve " +
		"ever seen. Reason cannot explain why our weaponry doesn’t affect these soldiers. \n\n“And the soldiers look the part. They descended upon us like a military " +
		"that was just waiting for an excuse. Dressed in blindingly golden armor with wings spread wide as they looked down upon us. They carried flaming swords but I " +
		"think it was more to fit the idea people had created for them. It wasn’t like they need the weapons. Immediately upon arrival, a few of the most faithful " +
		"vanished in their light. We were told those people were spared and sent to paradise, but I’ve never heard of people screaming as they go to paradise.\n\n“The " +
		"rest of us now live with the angels surrounding us. We are removed at their discretion and we can only keep moving. But how do fight something that all your " +
		"life you were told is impossible to defeat? \n\n“Just remember, if you thought you believed enough, were faithful enough, pure enough, and worshipped hard enough...you were wrong.”";
	public const string ANGELS_MAIN_TEXT1 = "Just what was the purpose of humanity? To spread peace and love? To worship a god? Or just to spread pain and malcontent? " +
		"Whatever the case, the divine was no longer satisfied with what it had created. \n\nIf there’s one area in which preachers have always excelled, it’s instilling fear " +
		"into the masses. All the speeches about eternal damnation, all the fear about letting demons into one’s home or letting sin take root. Eventually, it was dismissed " +
		"as nonsense. The world was in a chaotic state. There wasn’t a lot of room for belief when nations were constantly at war, and one had to tread carefully outside " +
		"their homes. So when the preachers, all preachers, started talking about the end of days, few listened. \n\nWhen they came, their arrival extinguished the sun. " +
		"Earth still stands, but it stands in an eternal night. The sky was torn asunder, and the golden-clad army of heaven descended. Some of the most pious and faithful " +
		"were consumed on the spot, screaming as their bodies were consumed in divine light. The rest were to be exterminated by hand.\n\nTraditional weaponry doesn’t seem to " +
		"have an effect. Whatever is to be done, it must be done quickly. Without the sun, crops will wither and die. If the angels do not consume all, starvation will.";
	public const string ANGELS_SUCCESS_TEXT = "As the angels returned to their domain, the sun reignited with their departure. The streets were filled with silent " +
		"onlookers as they watched the first sunrise in weeks. Some wept. Humanity has survived another day.";
	public const string ANGELS_FAILURE_TEXT = "Many were prepared for all out war with the rest of the world. But they were not prepared for a war with heaven itself. " +
		"The extermination was quick, but certainly not painless. Their haunted screams still echo through the empty streets. Divine wrath was the end of all things.";
    public const string ANGELS_SOLVE_BUTTON_0_TEXT = "Research Violent Cure (Sci -100 Mili -40)";
    public const string ANGELS_SOLVE_BUTTON_1_TEXT = "Pray for Forgiveness (Rel -150)";

    // These constants will govern how Angels affects your stats every turn.
    public const int ANGELS_POPULATION_REDUCTION = 80;
	public const int ANGELS_MILITARY_REDUCTION = 20;
	public const int ANGELS_RELIGION_REDUCTION = 40;

	// These constants will allow you to solve Angels
	// This set allows you to fight the angels by finding their weaknesses and expoiting them.
	public const int ANGELS_SCIENCE_SOLVE = 100;
	public const int ANGELS_MILITARY_SOLVE = 40;

	// This extremely difficult constraint will allow you to survive thanks to your pious people.
	public const int ANGELS_RELIGION_SOLVE = 150;
    #endregion

    #endregion


    #region Events
    // These events will complicate the apocalypses. Some are generic, some are specific.
    #region Adverse Weather
    // Generic event
    public const string WEATHER_EVENT_STRING = "Adverse Weather";
	public const string WEATHER_EVENT_TEXT = "A mass of super storms is gathering on the oceans. They will rage across the world. " +
	"It will be difficult for many to leave their homes in the coming days, and some basic infrastructure will be damaged amidst the torrents of wind and rain.";

	public const int WEATHER_POPULATION_REDUCTION = 30;
	public const int WEATHER_ECONOMY_REDUCTION = 20;
    public const string WEATHER_SOLVE_TEXT = "Reinforce Houses (Econ -75)";
	// You can solve this event by building shelters for the people
	public const int WEATHER_ECONOMY_SOLVE = 75;
	#endregion

	#region Drought
	// Generic event
	public const string DROUGHT_EVENT_STRING = "Drought";
	public const string DROUGHT_EVENT_TEXT = "As if things couldn't have gotten any worse, it seems that the world faces a global drought. Many wells are running dry, and the " +
		"people are struggling to ration water.";
    public const string DROUGHT_EVENT_SOLVE = "Ration Water (Mili -40, Econ -20)";

	public const int DROUGHT_POPULATION_REDUCTION = 50;

	// In order to solve this event, one must set up martial law and ration water
	public const int DROUGHT_MILITARY_SOLVE = 40;
	public const int DROUGHT_ECONOMY_SOLVE = 20;
	#endregion

	#region Famine Mutation
	// Famine-specific event
	public const string FAMINE_MUTATION_EVENT_STRING = "Mutation";
	public const string FAMINE_MUTATION_EVENT_TEXT = "This disease, whatever it is, is evolving faster than the science community anticipated. It is becoming obvious how " +
		"this virus has managed to thwart all the early attempts at containment.";

	public const int FAMINE_MUTATION_SCIENCE_REDUCTION = 70;

    public const string FAMINE_MUTATION_SOLVE_TEXT1 = "Research New Cure (Sci -40, Econ -30)";

	// In order to solve this, you're going to need to very quickly combat the mutation before it kills your science score
	public const int FAMINE_MUTATION_SCIENCE_SOLVE = 40;
	public const int FAMINE_MUTATION_ECONOMY_SOLVE = 30;
	#endregion

	#region Famine Plague
	// Famine-specific event... from the bible
	public const string FAMINE_PLAGUE_EVENT_STRING = "Plague of Insects";
	public const string FAMINE_PLAGUE_EVENT_TEXT = "Just like a story straight out of an ancient religious text, swarms of insects have been seen inting over the countryside. " +
		"These mutated bugs seem to be attacking people on site, though thankfully they don't live long.";

    public const string FAMINE_PLAGUE_SOLVE_TEXT0 = "Pray for Redemption (Rel -60)";
    public const string FAMINE_PLAGUE_SOLVE_TEXT1 = "Research Poison (Mili -20, Sci -20, Econ -20)";


    public const int FAMINE_PLAGUE_POPULATION_REDUCTION = 30;
	public const int FAMINE_PLAGUE_RELIGION_REDUCTION = 30;

	// Holy shit, religion is relevant to this one! Woo hoo!
	public const int FAMINE_PLAGUE_RELIGION_SOLVE = 60;

	// You can also solve it with some good ol' martial law, some scientists, and plenty of bug spray.
	public const int FAMINE_PLAGUE_MILITARY_SOLVE = 20;
	public const int FAMINE_PLAGUE_SCIENCE_SOLVE = 20;
	public const int FAMINE_PLAGUE_ECONOMY_SOLVE = 20;
	#endregion

	#region Famine Evolution
	// Famine-specific event
	public const string FAMINE_EVOLUTION_EVENT_STRING = "Evolution";
	public const string FAMINE_EVOLUTION_EVENT_TEXT = "Like so many diseases before it, the necrotic poison has evolved to become infections between humans. It can be contained, but not " +
		"before it spreads.";
    public const string FAMINE_EVOLUTION_SOLVE_TEXT0 = "Research a Cure (Econ -70)";
    public const string FAMINE_EVOLUTION_SOLVE_TEXT1 = "Quarantine Zones (Mili -70)";

    public const int FAMINE_EVOLUTION_POPULATION_REDUCTION = 40;

	// If you have enough science, you can slow the spread of the disease and potentially cure it
	public const int FAMINE_EVOLUTION_SCIENCE_SOLVE = 70;

	// If you have enough military, you can create quarantine zones.
	public const int FAMINE_EVOLUTION_MILITARY_SOLVE = 70;
	#endregion

	#region Famine Breakthrough
	//Famine-specific... good event? Neat!
	public const string FAMINE_BREAKTHROUGH_EVENT_STRING = "Scientific Breakthrough";
	public const string FAMINE_BREAKTHROUGH_EVENT_TEXT = "The scientific community has managed to discover something unique about the biology of the necrotic disease. The tests are " +
		"very promising. Perhaps the world might just make it through.";
    public const string FAMINE_BREAKTHROUGH_SOLVE_TEXT = "Disperse Cure (Sci +100)";

	public const int FAMINE_BREAKTHROUGH_SCIENCE_INCREASE = -100;
	#endregion

	#region Zombies Evolution
	// Zombies-specific event
	public const string ZOMBIES_EVOLUTION_EVENT_STRING = "Accelerated Evolution";
	public const string ZOMBIES_EVOLUTION_EVENT_TEXT = "The virus seems to be changing faster than it can be cured. As soon as a strand is killed, another has already evolved. " +
		"Scientists are losing hope that the world can survive.";
	public const int ZOMBIES_EVOLUTION_SCIENCE_REDUCTION = 60;
    public const string ZOMBIES_EVOLUTION_SOLVE_TEXT = "Invest in Science (Econ -40)";
    // With enough brute force investment, you can get your scientists more materials with which to work, eventually overcoming this problem
    public const int ZOMBIES_EVOLUTION_ECOMONY_SOLVE = 40;
	#endregion

	#region Zombies Horde
	// Zombies-specific event
	public const string ZOMBIES_HORDE_EVENT_STRING = "Horde Behavior";
	public const string ZOMBIES_HORDE_EVENT_TEXT = "It appears that the reanimated population has begun to horde behavior. They travel in packs or large flocks, and " +
		"aren't so much organized as they are overwhelming. Survivors are advised to rest in high places and not draw attention to themselves.";
	public const int ZOMBIES_HORDE_MILITARY_REDUCTION = 80;
	public const int ZOMBIES_HORDE_POPULATION_REDUCTION = 20;
    public const string ZOMBIES_HORDE_SOLVE_TEXT0 = "Military Force (Mili -60)";
    public const string ZOMBIES_HORDE_SOLVE_TEXT1 = "Invest in Science (Sci -30, Econ -30)";
    // With enough military might, you can destroy the hordes
    public const int ZOMBIES_HORDE_MILITARY_SOLVE = 60;

	// If you have the right materials, you can get the virus to evolve out of horde behavior with complex planning
	public const int ZOMBIES_HORDE_SCIENCE_SOLVE = 30;
	public const int ZOMBIES_HORDE_ECONOMY_SOLVE = 30;
	#endregion

	#region Zombies Mutation
	// Zombies-specific event
	public const string ZOMBIES_MUTATION_EVENT_STRING = "Mutating Monsters";
	public const string ZOMBIES_MUTATION_EVENT_TEXT = "The virus seems to be manipulating the bodies of their hosts into mutated husks. Within days, they can rapidly harden " +
	"their skin to become more resistant, and seem to be able to move faster and hit harder. Some stranger, unique mutations have also been seen.";
	public const int ZOMBIES_MUTATION_MILITARY_REDUCTION = 80;
    public const string ZOMBIES_MUTATION_SOLVE_TEXT = "Develop new Weapons (Sci -40, Econ -40)";

    // You can solve this problem with enough science and money to develop better weaponry
    public const int ZOMBIES_MUTATION_SCIENCE_SOLVE = 40;
	public const int ZOMBIES_MUTATION_ECONOMY_SOLVE = 40;
	#endregion

	#region Angels Minions
	// Angels-specific event
	public const string ANGELS_MINIONS_EVENT_STRING = "Corruption of the Blessed";
	public const string ANGELS_MINIONS_EVENT_TEXT = "The angels didn't just come with a battalion of soldiers. They took human souls as well. Those who prayed for " +
	"mercy were given a new life as slave labor. Canon fodder for the real army.";
    public const string ANGELS_MINIONS_SOLVE_TEXT = "Military Action (Mili -60)";
	public const int ANGELS_MINIONS_POPULATION_REDUCTION = 50;
	public const int ANGELS_MINIONS_RELIGION_REDUCTION = 40;

	// You can solve this with sheer military force
	public const int ANGELS_MINIONS_MILITARY_SOLVE = 60;
	#endregion

	#region Angels Hellfire
	// Angels-specific event
	public const string ANGELS_HELLFIRE_EVENT_STRING = "Heaven's Hellfire";
	public const string ANGELS_HELLFIRE_EVENT_TEXT = "It appears as though the angels were holding back when they arrived. The strongest among them, the Seraphim, " +
	"can see the sins of the wicked and use them as a catalyst to bring forth the fires of hell itself as punishment.";
	public const int ANGELS_HELLFIRE_POPULATION_REDUCTION = 60;
    public const string ANGELS_HELLFIRE_SOLVE_TEXT = "Pray for Redemption (Rel -60)";

	// You can solve this by having your people be pious enough
	public const int ANGELS_HELLFIRE_RELIGION_SOLVE = 60;
	#endregion

	#region Angels Plague
	// Angels-specific event
	public const string ANGELS_PLAGUE_EVENT_STRING = "Biblical Plagues";
	public const string ANGELS_PLAGUE_EVENT_TEXT = "Just as when Moses confronted Pharoah, the angels are calling upon the wrath of god to unleash plagues upon humanity.";
    public const string ANGELS_PLAGUE_SOLVE_TEXT = "Pray and Research (Sci -40, Rel -40)";
    public const int ANGELS_PLAGUE_POPULATION_REDUCTION = 40;
	public const int ANGELS_PLAGUE_MILITARY_REDUCTION = 70;

	// With a combination of biblical knowledge and science, it is possible to predict the next plague and find a way to ease its affects
	public const int ANGELS_PLAGUE_SCIENCE_SOLVE = 40;
	public const int ANGELS_PLAGUE_RELIGION_SOLVE = 40;
	#endregion

#endregion
}
