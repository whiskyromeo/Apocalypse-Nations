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

	// These constants will govern how Famine affects your stats every turn.
	public const double FAMINE_POPULATION_REDUCTION = 10.0;
	public const double FAMINE_SCIENCE_REDUCTION = 5.0;
	public const double FAMINE_ECONOMY_REDUCTION = 7.0;

	// These constants will allow you to solve Famine
	// This first set will allow you to cure the disease with enough investment of science and money. It is more difficult, but will lose you less people.
	public const double FAMINE_SCIENCE_SOLVE = 30.0;
	public const double FAMINE_ECONOMY_SOLVE = 40.0;

	// This will let you set up martial safe zones. Many will die, but your people will survive.
	public const double FAMINE_MILITARY_SOLVE = 50.0;
	#endregion
#endregion


#region Events
// These events will complicate the apocalypses. Some are generic, some are specific.
	#region Adverse Weather
	// Generic event
	public const string WEATHER_EVENT_STRING = "Adverse Weather";
	public const string WEATHER_EVENT_TEXT = "A mass of super storms is gathering on the oceans. They will rage across the world. " +
	"It will be difficult for many to leave their homes in the coming days, and some basic infrastructure will be damaged amidst the torrents of wind and rain.";

	public const double WEATHER_POPULATION_REDUCTION = 5.0;
	public const double WEATHER_ECONOMY_REDUCTION = 3.0;

	// You can solve this event by building shelters for the people
	public const double WEATHER_ECONOMY_SOLVE = 20.0;
	#endregion

	#region Drought
	// Generic event
	public const string DROUGHT_EVENT_STRING = "Drought";
	public const string DROUGHT_EVENT_TEXT = "As if things couldn't have gotten any worse, it seems that the world faces a global drought. Many wells are running dry, and the " +
		"people are struggling to ration water.";

	public const double DROUGHT_POPULATION_REDUCTION = 7.0;

	// In order to solve this event, one must set up martial law and ration water
	public const double DROUGHT_MILITARY_SOLVE = 15.0;
	public const double DROUGHT_ECONOMY_SOLVE = 15.0;
	#endregion

	#region Famine Mutation
	// Famine-specific event
	public const string FAMINE_MUTATION_EVENT_STRING = "Mutation";
	public const string FAMINE_MUTATION_EVENT_TEXT = "This disease, whatever it is, is evolving faster than the science community anticipated. It is becoming obvious how " +
		"this virus has managed to thwart all the early attempts at containment.";

	public const double FAMINE_MUTATION_SCIENCE_REDUCTION = 7.0;

	// In order to solve this, you're going to need to very quickly combat the mutation before it kills your science score
	public const double FAMINE_MUTATION_SCIENCE_SOLVE = 20.0;
	public const double FAMINE_MUTATION_ECONOMY_SOLVE = 15.0;
	#endregion

	#region Famine Plague
	// Famine-specific event... from the bible
	public const string FAMINE_PLAGUE_EVENT_STRING = "Plague of Insects";
	public const string FAMINE_PLAGUE_EVENT_TEXT = "Just like a story straight out of an ancient religious text, swarms of insects have been seen doubleing over the countryside. " +
		"These mutated bugs seem to be attacking people on site, though thankfully they don't live long.";

	public const double FAMINE_PLAGUE_POPULATION_REDUCTION = 3.0;
	public const double FAMINE_PLAGUE_RELIGION_REDUCTION = 3.0;

	// Holy shit, religion is relevant to this one! Woo hoo!
	public const double FAMINE_PLAGUE_RELIGION_SOLVE = 40.0;

	// You can also solve it with some good ol' martial law, some scientists, and plenty of bug spray.
	public const double FAMINE_PLAGUE_MILITARY_SOLVE = 10.0;
	public const double FAMINE_PLAGUE_SCIENCE_SOLVE = 10.0;
	public const double FAMINE_PLAGUE_ECONOMY_SOLVE = 10.0;
	#endregion

	#region Famine Evolution
	// Famine-specific event
	public const string FAMINE_EVOLUTION_EVENT_STRING = "Evolution";
	public const string FAMINE_EVOLUTION_EVENT_TEXT = "Like so many diseases before it, the necrotic poison has evolved to become infections between humans. It can be contained, but not " +
		"before it spreads.";
	public const double FAMINE_EVOLUTION_POPULATION_REDUCTION = 7.0;

	// If you have enough science, you can slow the spread of the disease and potentially cure it
	public const double FAMINE_EVOLUTION_SCIENCE_SOLVE = 30.0;

	// If you have enough military, you can create quarantine zones.
	public const double FAMINE_EVOLUTION_MILITARY_SOLVE = 30.0;
	#endregion

	#region Famine Breakthrough
	//Famine-specific... good event? Neat!
	public const string FAMINE_BREAKTHROUGH_EVENT_STRING = "Scientific Breakthrough";
	public const string FAMINE_BREAKTHROUGH_EVENT_TEXT = "The scientific community has managed to discover something unique about the biology of the necrotic disease. The tests are " +
		"very promising. Perhaps the world might just make it through.";

	public const double FAMINE_BREAKTHROUGH_SCIENCE_INCREASE = 10.0;
	#endregion
#endregion
}
