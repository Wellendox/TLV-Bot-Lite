namespace TLVBot.Modules.Normal;

public class Quote : TlvInteractionModuleBase, IQuote
{
    private readonly string[] _singleQuote =
    {
        "User1: \"Do you think getting attention is hot, or is it just a bit gay?\"",
        "User1: \"A real man pushes himself out of bed with his dick.\"",
        "User1: \"Someone did a fucky wucky and now you have to get into the forever box.\"",
        "User1: \"I got carried away by the song and I broke a mirror in the gym.\"",
        "User1: \"STOP QUOTING ME! I CAN SEE YOU TYPING! STOP!\"",
        "User1: \"Coffee wont cure your coffee.\"",
        "User1: \"Do you think 'Dock' is just a combination of 'Dick' and 'Cock'?\"",
        "User1: \"If you cum in the snow, no one will know.\"",
        "User1: \"The activity of making two penises kiss is called space docking.\"",
        "User1: \"I'll leave my hotdog in your backside.\"",
        "User1: \"Luck is for people without skill.\"",
        "User1: \"There's nothing wrong with roleplaying in Goldshire to be honest.\"",
        "User1: \"The best RP happens in SW's Trade District.\"",
        "User1: \"Pain.\"",
        "User1: \"I always got a spare banger for the homies.\"",
        "User1: \"Imagine thinking the mods in here will do their job.\"",
        "User1: \"The Lidlverse is a sophisticated society of Beethoven enthusiasts.\"",
        "User1: \"I thought this was a serious RP Discord Server.\"",
        "User1: \"I actually have a futa character, which puts all Goldshire roleplayers to shame.\"",
        "User1: \"Nothing wrong with dragon roleplayers, honestly.\"",
        "User1: \"Death by cock, I'm all about it. Fucking kill me.\"",
        "User1: \"I’ve come to a point in my life where I need a stronger word than fuck..\"",
        "User1: \"I wish I died and came back as a cowboy at Ram Ranch.\"",
        "User1: \"I smell like a turtle.\"",
        "User1: \"You think I really give a fuck? I can’t even read.\"",
        "User1: \"BEHOLD, the field in which I grow my fucks! Lay thine eyes upon it, and thou shalt see that it is barren!\"",
        "User1: \"Well, well, well... if it isn’t my old friend: the dawning realization that I fucked up bad.\"",
        "User1: \"I’m sick and tired of being called 'mortal' like, you don’t know that. Neither do I. I have never died even ONCE. Nothing has been proven yet. Stop making assumptions. It’s rude.\"",
        "User1: \"When someone points at your black clothes and asks whose funeral it is, having a look around the room and saying 'Haven’t decided yet' is typically a good response.\"",
        "User1: \"So apparently the 'bad vibes' I’ve been feeling are actually severe psychological distress\""
    };

    private readonly string[] _doubleQuote =
    {
        "User1: \"How skinny do you think I am?\"\nUser2: \"You're not. You're fat.\"",
        "User1: \"User2!!\"\nUser2: \"User1!\"\nUser1: \"Hi.\"\nUser2: \"You drunk?\"\nUser1: \"Yes, but don't tell User1...\"",
        "User1: \"We have those chocolate goblins... you know? What do you call them?\"\nUser2: \"Elves?\"\nUser1: \"Yes. Those.\"",
        "User1: \"You saved me. I owe you my life.\"\nUser2: \"No thanks. I’ve seen it and I’m not very impressed.\"",
        "User1: \"Name a more iconic duo than my crippling fear of abandonment and my anxiety. I'll wait.\"\nUser2: \"You and me!!!\"\nUser1, tearing up: \"Okay.\"",
        "User1: \"Fuck.\"\nUser2: \"We've got to work on your cursing.\"\nUser1: \"Why? I'm pretty good at cursing already.\"",
        "User1: \"You kill people for money?!\"\nUser2: \"I can explain!\"\nUser1: \"And all this time I’ve been doing it for free like a chump!\"",
        "User1: \"I slept for almost 12 hours but I might still be tired so lets go for 12 more just incase.\"\nUser2: \"User1, that's a coma.\"\nUser1: \"Sounds festive.\"",
        "User1: \"I'm a reverse necromancer.\"\nUser2: \"Isn't that just killing people?\"\nUser1: \"Ah, technicality.\"",
        "User1: \"User2... Why did you draw a pentagram on the floor?\"\nUser2: \"Your text told me to satanize the house before you returned.\"\nUser1: \". . .\"\nUser1: \"I wrote sanitize, User2.\"",
        "User1: \"I've already sent good vibes your way… they’re coming. There’s nothing you can do to stop them.\"\nUser2: \"This is the most threatening way I’ve ever been cheered up.\"",
        "User1: \"Sorry it took me so long to bail you out of jail.\"\nUser2: \"No it’s my fault, I shouldn’t’ve used my one phone call to prank call the police.\"",
        "User1: \"Please, I'm begging you go to a doctor.\"\nUser2: \"I'm sorry is this OUR stab wound? Stay out of it.\""
    };

    private readonly string[] _tripleQuote =
    {
        "User1: \"User2, what do IDK, LY, and TTYL mean?\"\nUser2: \"I don’t know, love you, talk to you later.\"\nUser1: \"Ok, I love you too, I’ll just ask User3.\"",
        "User1: \"If I die, my funeral is going to be the biggest party ever and you’re all invited\"\nUser2: \"If?\"\nUser3: \"Great, the only party I’ve ever been invited to and they might not even die.\"",
        "User1: \"I trust User3.\"\nUser2: \"You think they know what they're doing?\"\nUser3: \"I wouldn't go that far.\"",
        "User1: \"Naturally, we are on the cutting edge of technology.\"\nUser2, amazed: \"Wow...\"\nUser3, to User2: \"Well what does that mean?\"\nUser2: \"I don't know.\"\nUser2, to User1: \"What does that mean?\"",
    };

    private readonly string[] _quadQuote =
    {
        "User1: \"Yo is User4 sleeping or dead?\"\nUser2: \"Hopefully dead, I hated their guts.\"\nUser3: \"Yeah, so did I.\"\nUser4: \"Okay first of all, fuck you-\"",
        "User1: \"Truth or dare?\"\nUser2: \"Dare\"\nUser1: \"I dare you to kiss the hottest person in the room\"\nUser2: \"Hey User3..\"\nUser3, blushing: \"Yeah?\"\nUser2: \"Could you move? I'm trying to get to User4.\"",
        "User1: \"You know those things will kill you, right?\"\nUser2, pouring another glass of whiskey:: \"That’s the point.\"\nUser3, smoking a cigarette: \"We’re trying to speed up the process.\"\n*User4 nods while eating raw cookie dough*"
    };

    private readonly string[] _quintQuote =
    {
        "User1: \"What did you guys get in your yearbook?\"\nUser2: \"Prettiest Smile.\"\nUser3: \"Nicest Personality.\"\nUser4: \"Most likely to start a bar fight.\"\nUser5: \"Least likely to start a bar fight, but most likely to win one.\"",
        "User1: \"What’s something you guys are better than User2 at?\"\nUser3: \"Mario Kart.\"\nUser4: \"Yeah, video games.\"\nUser5: \"Emotional vulnerability.\"",
        "User1: \"I’m an idiot.\"\nUser2: \". . .\"\nUser3: \". . .\"\nUser4: \". . .\"\nUser5: \". . .\"\nUser2: \"If you’re waiting for us to disagree, this is going to be a long day.\"\n"
    };

    [SlashCommand("quote", "Fake quotes, like that weird meme webpage. Try it out.")]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task QuoteAsync(SocketGuildUser user, SocketGuildUser? user2 = null, SocketGuildUser? user3 = null, SocketGuildUser? user4 = null, SocketGuildUser? user5 = null)
    {
        Random rnd = new Random();

        if (user2 == null) //One person tagged
        {
            string fetchedQuote = _singleQuote[rnd.Next(0, _singleQuote.Length - 1)];
            string finalQuote = Regex.Replace(fetchedQuote, @"\bUser1\b", user.Nickname ?? user.Username);
            await RespondAsync(finalQuote);
        }
        else if (user3 == null) //Two persons tagged
        {
            string fetchedQuote = _doubleQuote[rnd.Next(0, _doubleQuote.Length - 1)];
            string firstQuote = Regex.Replace(fetchedQuote, @"\bUser1\b", user.Nickname ?? user.Username);
            string finalQuote = Regex.Replace(firstQuote, @"\bUser2\b", user2.Nickname ?? user2.Username);
            await RespondAsync(finalQuote);
        }
        else if (user4 == null) //Three persons tagged
        {
            string fetchedQuote = _tripleQuote[rnd.Next(0, _tripleQuote.Length - 1)];
            string firstQuote = Regex.Replace(fetchedQuote, @"\bUser1\b", user.Nickname ?? user.Username);
            string secondQuote = Regex.Replace(firstQuote, @"\bUser2\b", user2.Nickname ?? user2.Username);
            string finalQuote = Regex.Replace(secondQuote, @"\bUser3\b", user3.Nickname ?? user3.Username);
            await RespondAsync(finalQuote);
        }
        else if (user5 == null) //Four persons tagged
        {
            string fetchedQuote = _quadQuote[rnd.Next(0, _quadQuote.Length - 1)];
            string firstQuote = Regex.Replace(fetchedQuote, @"\bUser1\b", user.Nickname ?? user.Username);
            string secondQuote = Regex.Replace(firstQuote, @"\bUser2\b", user2.Nickname ?? user2.Username);
            string thirdQuote = Regex.Replace(secondQuote, @"\bUser3\b", user3.Nickname ?? user3.Username);
            string finalQuote = Regex.Replace(thirdQuote, @"\bUser4\b", user4.Nickname ?? user4.Username);
            await RespondAsync(finalQuote);
        }
        else //All tagged
        {
            string fetchedQuote = _quintQuote[rnd.Next(0, _quintQuote.Length - 1)];
            string firstQuote = Regex.Replace(fetchedQuote, @"\bUser1\b", user.Nickname ?? user.Username);
            string secondQuote = Regex.Replace(firstQuote, @"\bUser2\b", user2.Nickname ?? user2.Username);
            string thirdQuote = Regex.Replace(secondQuote, @"\bUser3\b", user3.Nickname ?? user3.Username);
            string fourthQuote = Regex.Replace(thirdQuote, @"\bUser4\b", user4.Nickname ?? user4.Username);
            string finalQuote = Regex.Replace(fourthQuote, @"\bUser5\b", user5.Nickname ?? user5.Username);
            await RespondAsync(finalQuote);
        }
    }
}