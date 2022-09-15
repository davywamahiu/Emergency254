using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Emergency254.Models;

namespace Emergency254.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Icon="covid1.png", Text = "Corona Virus, Covid-19 Tips", Description="The following info is important, covid-19 Symptoms include.", FirstAid="Do Not stay at home inform the naerest health center do not endager lives of fellow Kenyans", Sub1="1. Fever mild to high, more than two days", Sub2="2. Runny nose", Sub3="3. Headache", Sub4="4. Diarrhea", Sub5="5. Vomitting", Sub6="6. Sore throat", Sub7="7. Loss of smell and some times taste", Final="Some Symptoms may be attributed to other diseases, but do not take things for granted", Others="Report if symptom last beyond four days",
                Prevention="The following can be done to help mitigate covid-19", Prevention1="1. Wash Hands regularly with sanitizer and clean tap water", Prevention2="2. Keep at least 1.5 meters apart", Prevention3="3. Avoid Large gatherings or crowded places.", Prevention4="4. Wear a mask in public places, vehicles, buses etc.", Icon1="hands.png", Icon2="social.png", Icon3="handshake.png", Icon4="mask1.png"},
                new Item { Id = Guid.NewGuid().ToString(), Icon="floods.jpg", Text = "Flash Floods", Description="Floods can be devastating and rock havoc... read more", FirstAid="The content is organized into 3 categories Low Alert, Medium Alert and High Alert.", Sub1="1. Pay attention near natural banks that can be destabilized or unstable.", Sub2="2. Stay vigilant and regularly monitor the level of rivers, Keep off the river banks in the event of rapid level rise, rapid increase in stream velocity or arrival waves.", Sub3="3. Cross rivers slowly and check for possible overflow when walking or driving along riverbanks", Sub4="4. In the floodable zones, secure goods and belongings in a safe place above known high water level or in upper floors", Sub5="5. If it is absolutely necessary tomove, be very careful.Respect and follow, in particular, the deviations established.Avoid routes along rivers.", Sub6="6. Stay permanently informed of the evolving weather conditions", Sub7="7. Inform relatives or colleaguesto your movements, departure and destination.", Others="Respect the order of evacuation and facilitate the work of rescuers Do not undertake any movement with a boat without having taken all security measures(life jackets, etc...) and have a supply of drinking water.", Final="Never, by foot or by car, go into a submerged footpath, or any underground place, car park, or cellar below street level even if there is apparently no water inside.",
                Prevention="If it is necessary to move, be very careful", Prevention1="1. Stay away from rivers and flooded areas", Prevention2="2. Do not engage in any way, on foot or by car on a submerged road.", Prevention3="3. In urban areas, never go down steep streets where water is flowing rapidly and carrying objects.", Prevention4="4. Have waterproof emergency lighting and a supply of drinking water with you.", Icon1="floods.png", Icon2="floods.png", Icon3="floods1.jpg", Icon4="floods1.png"},
                new Item { Id = Guid.NewGuid().ToString(), Icon="pikipiki.png", Text = "Accidents", Description="accidents are a major scare when they happen...", FirstAid="Do Not stay at home inform the naerest health center.", Sub1="Accidents handling and precations", Sub2="2. Vehicles accidents", Sub3="3. Air crash", Sub4="4. Boat tragedies", Sub5="5. Train Tragedies", Sub6="6. Construction Accidents, building collapse", Sub7="7. Other Accidents, fires etc", Others="There are many forms of accidents", Final="Accidents such as road accidents should be handled with care, DO NOT touch blood oozing from a road accident person, Report major accidents to National Disaster operations center through the app.",
                Prevention="The following can be done to help mitigate Accidents", Prevention1="1. The accidents can be handled in so may ways depending on where they happend, type and how they happend.", Prevention2="2. Accidents such as road accidents should be handled with care, DO NOT touch blood oozing from a road accident person", Prevention3="3. Avoid Large gatherings, crowded place around the scene of an accident.", Prevention4="4. Report accidents that need national attention to us through the app, ie if a building collapses.", Icon1="accident.jpg", Icon2="accident1.jpg", Icon3="accident.jpg", Icon4="pikipiki.png"},
                new Item { Id = Guid.NewGuid().ToString(), Icon="shocker.png", Text = "Snake Bite", Description="A sharp pain like of a niddle, where two tinny spots oozing with blood may appear on your body.",FirstAid="Ask for emergency treatment with snake wound in the immediate hospital.", Sub1="Observe for a crwaling(slithering animal elongated like a rope)", Sub2="2. Observe for a crwaling(slithering animal elongated like a rope).", Sub3="3. if it is a snake or you assume to be a snake.", Sub4="4. 1. Look for a tight cloth or string and tire above the wound and bellow.", Sub5="5. Wash the wound with clean water.", Sub6="6. Rush to the nearest hospital", Sub7="7. Ask for emergency treatment with snake wound.", Others="NB: if possible carry the snake along", Final="Please do not stay at home, snake bites could kill you. Report major accidents to National Disaster management through the app.",
                Prevention="The following can be done to help mitigate Snake bites", Prevention1="1. Tie above and below the wound to prevent blood circulation tightly", Prevention2="2. wash the wound with clean water", Prevention3="3. get to the nearest hospital and ask for emregency treatment of snake bites.", Prevention4="4. Inform us through the app if the snake bite took place in a remote location with little or no access.", Icon1="snake.jpg", Icon2="snake2.jpg", Icon3="snake.jpg", Icon4="shocker.png"},
                new Item { Id = Guid.NewGuid().ToString(), Icon="hazard.png", Text = "Poisoning, Bio Hazards and pollution", Description="These are chemicals that when consumed may kill, maime...", FirstAid="Ask for emergency treatment with possibly the chemical used.", Sub1="1. Eating food from unclean hotels, or in unhygenic conditions", Sub2="2. Avoid eating suspicious food from untrustworthy people.", Sub3="3. Eating bread, chapatis, mandazi that may have traces of mould or may have overstayed.", Sub4="4. Accepting donations of food, water from unkown sources.", Sub5="5. Solid waste disposal into rivers, from industries.", Sub6="6. Burning plastics, poisons the air, it may lead to toxic rainfall, inhallation may lead to poisoning", Sub7="7. Taking overdose or underdose clinical medicine, Taking nacotics may also lead to poisoning, taking non human drugs ie rat poison, fertilisers, insectcides, herbicides, pesticides etc.", Others="Poisoning could kill you, do not ignore common illnesses such as stomach pains, seek help whenever possible.", Final="Food posoning is the most common type of poisonng, please consume quality food. Other types of poisoning inlude air, water...",
                Prevention="The following can be done to help mitigate Posoning", Prevention1="1. Avoid eating food from unclean hotels, or in unhygenic conditions", Prevention2="2. Avoid eating bread, chapatis, mandazi that may have traces of mould or may have overstayed.", Prevention3="3. Avoid Eating rotten maize, afro toxin maize.", Prevention4="4. Do not dispose waste in into rivers, dispose solid waste properly, avoid burning plastics openly use incenarators.", Icon1="sell.png", Icon2="mkt.png", Icon3="agrics1.png", Icon4="dustbin.png"},
                new Item { Id = Guid.NewGuid().ToString(), Icon="hazard.png", Text = "Earth Quakes", Description="Bio hazards are very dangerous chemicals which may cause extensive damage to human, animal and plant life.", FirstAid="Always report any solid waste disposal being done illegally", Sub1="Avoid drinking unclean water,  possibly inform us of solid watse disposal from industries", Sub2="2. Runny nose", Sub3="3. Headache", Sub4="4. Diarrhea", Sub5="5. Vomitting", Sub6="6. Sore throat", Sub7="7. Loss of smell and some times taste", Others="Report if symptom last beyond four days", Final="Ensure you do not walk on solid waste bare foot, Illegal dumping of solid waste should be reported, illegal construction of industries should also be reported.",
                Prevention="The following can be done to help mitigate EathQuakes", Prevention1="1. Wash Hands regularly with sanitizer and clean tap water", Prevention2="2. Keep at least 1.5 meters apart", Prevention3="3. Avoid Large gatherings or crowded places.", Prevention4="4. Wear a mask in public places, vehicles, buses etc.", Icon1="hands.png", Icon2="social.png", Icon3="handshake.png", Icon4="mask.png"},
                new Item { Id = Guid.NewGuid().ToString(), Icon="fire.png", Text = "Fires", Description="Fire causes can be many please notify the nearest fire brigade ...", FirstAid="Run for your life if the fire is uncontrollable do not risk going in as you may lose your life too.", Sub1="Dealing with fires is a delicate afair", Sub2="1. Wildfires due to excessive heat. At times human carelessness ie smokers", Sub3="2. Electrical faults, unsealed wires, overload. Power surge etc", Sub4="3. Gas cylinders", Sub5="4. Unattended canddles, koroboi, lanterns", Sub6="5. Deliberate fires. arson", Sub7="6. Jikos", Others= "Report any catastrophic fires to National Disaster operations center through the app.", Final="Run for your life if the fire is uncontrollable do not risk going in as you may lose your life too.",
                Prevention="The following can be done to help mitigate Fires and stay safe", Prevention1="1. Take a deep breath and get your strategies right, call the fire department for help.", Prevention2="2.  Never leave leaving any gas cylinders, stoves, jikos, coils, koroboi, lanterns on while going away, Avoid electronic socket overloads", Prevention3="3. Always remenber to take insurance cover to be safe if you can.", Prevention4="4. Repair any broken electronic devices as they are good candidates for fires.", Icon1="fire.png", Icon2="fire.png", Icon3="fire.png", Icon4="fire.png"},
                new Item { Id = Guid.NewGuid().ToString(), Icon="locurst1.png", Text = "Locust Invasion", Description="Locust have of late been a menance to the Sub Saharan region due to climate change.", FirstAid="Make loud noise could scare the locust away, however pesticides are best. Inform the Government.", Sub1="The following information could be helpfull", Sub2="1. When you observe a swarm of locust.", Sub3="2. The locust could swarm in their thousands or millions", Sub4="3. The locust are likely to destroy an entire harvest, they could eat as much as 35,000 people in one day.", Sub5="4. The locust will lay as much as 1000 eggs per square meter", Sub6="5. The best way to deal with locust is by spraying pesticide to kill both insect and eggs.", Sub7="6. The locust can move as much as 200 kilometers on a single day.", Others="Do not delay informing the government as this could lead to extensive damages, please inform us through the app.", Final="Locust are a very destructive insect that can make people slip into hunger by limiting a harvest.",
                Prevention="The following can be done to help mitigate Locust Invasion", Prevention1="1. Scar the locust away by making noise", Prevention2="2. Spray them with insectsides", Prevention3="3. Protect the environment to prevent global warming.", Prevention4="4. Inform the national and county government using the app.", Icon1="locurst.jpg", Icon2="locurst1.jpg", Icon3="locurst.jpg", Icon4="locurst1.jpg"}
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}