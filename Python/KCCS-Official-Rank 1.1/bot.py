import discord
import json
import random
import time
from discord.ext import commands

TOKEN = 'NjkxMTExMjc5MzgwNjYwMjU0.Xu4S1A.KeQw02GA9FB37nlcjxZXlB_chD0'
bot = commands.Bot(command_prefix='+')


@bot.event
async def on_ready():
    print('Login as Misaka Mikoto')
    with open('user.json', 'r') as f:
        users = json.load(f)
    for membersname in users:
        await debug(users, membersname)
    with open('user.json', 'w') as f:
        json.dump(users, f, sort_keys=True, indent=2)


@bot.event
async def on_member_join(member):
    with open('./user.json', 'r') as f:
        users = json.load(f)
    await updata_data(users, member)
    with open('./user.json', 'w') as f:
        json.dump(users, f, sort_keys=True, indent=2)
    channel = bot.get_channel(726361811984842774)
    await channel.send(member + 'join in!')


@bot.event
async def on_message(message):
    if not (message.channel == discord.DMChannel):
        with open('./user.json', 'r') as f:
            users = json.load(f)
        if not message.author.bot:
            await updata_data(users, message.author)
            await add_experience(users, message.author)
            await level_up(users, message.author)
        for membersname in users:
            await debug(users, membersname)
        with open('./user.json', 'w') as f:
            json.dump(users, f, sort_keys=True, indent=2)
        await bot.process_commands(message)
    if message.author.id != 691111279380660254:
        channel = bot.get_channel(726361811984842774)
        await channel.send(message.author.name + ' - ' +
                           str(time.strftime("%M:%S", time.localtime())) +
                           ': ' + message.content + ' : ' +
                           str(message.channel))


async def updata_data(users, user):
    if not user.name in users:
        users[user.name] = {}
        users[user.name]['name'] = user.name
        users[user.name]['id'] = str(user.id)
        users[user.name]['avatar'] = str(
            user.avatar_url_as(static_format='png'))
        users[user.name]['exp'] = 0
        users[user.name]['msg'] = 0
        users[user.name]['lvl'] = 1
        users[user.name]['needExp'] = 0
        users[user.name]['balances'] = 0
    users[user.name]['name'] = user.name
    users[user.name]['avatar'] = str(user.avatar_url_as(static_format='png'))
    return users


async def add_experience(users, user):
    users[user.name]['exp'] += 5
    users[user.name]['msg'] += 1
    return users


async def level_up(users, user):
    exp = users[user.name]['exp']
    if users[user.name]['lvl'] != int(exp**(1 / 2)):
        users[user.name]['lvl'] = int(exp**(1 / 2))
    users[user.name]['needExp'] = (int(exp**(1 / 2)) + 1)**2 - exp
    return users


async def debug(users, user):
    if users[user]['exp'] != (users[user]['msg'] * 5):
        users[user]['exp'] = (users[user]['msg'] * 5)
    exp = users[user]['exp']
    if users[user]['lvl'] != int(exp**(1 / 2)):
        users[user]['lvl'] = int(exp**(1 / 2))
    users[user]['needExp'] = (int(exp**(1 / 2)) + 1)**2 - exp
    return users


@bot.command(name='rank', help='Get the rank')
async def rank(ctx, *, member: discord.Member = None):
    with open('./user.json', 'r') as f:
        users = json.load(f)
    if member == None:
        await ctx.send(
            '```{0}\'s Exp: {1}, Levels: {2}, Next Level Need: {3}```'.format(
                users[ctx.author.name]['name'], users[ctx.author.name]['exp'],
                users[ctx.author.name]['lvl'],
                users[ctx.author.name]['needExp']))
    else:
        if not member.name in users:
            await ctx.send('```That people didn\'t say anything!```')
        else:
            await ctx.send(
                '```{0}\'s Exp: {1}, Levels: {2}, Next Level Need: {3}```'.
                format(users[member.name]['name'], users[member.name]['exp'],
                       users[member.name]['lvl'],
                       users[member.name]['needExp']))


@bot.command(name='level', help='Get all the members rank')
async def level(ctx):
    await ctx.send(
        'Here is KCCS Official\'s leaderboard: https://KCCS-Official-Rank--stupidbenz.repl.co'
    )


@bot.command(name='check', help='Get your balance')
async def check(ctx):
    with open('user.json', 'r') as f:
        users = json.load(f)
    dm = bot.get_user(ctx.author.id)
    await dm.send('```Balance: {0}```'.format(
        users[ctx.author.name]['balances']))


@bot.command(name='give', alias='pay', help='Give some money to a member')
async def give(ctx, member: discord.User, amount):
    amount = int(amount)
    with open("./user.json", "r") as f:
        users = json.load(f)
    if users[ctx.author.name]["balances"] > amount:
        if amount == 0:
            await ctx.channel.purge(limit=1)
            await ctx.send('You can\'t give **ZERO** Kar')
        elif amount < 0:
            await ctx.channel.purge(limit=1)
            await ctx.send('You can\'t give **NEGATIVE** Kar')
        elif amount == 1:
            await ctx.channel.purge(limit=1)
            await ctx.send('I have sent {0} Kar'.format(amount))
            users[member.name]["balances"] += amount
            users[ctx.author.name]["balances"] -= amount

            with open("./user.json", "w") as f:
                json.dump(users, f, indent=2)
        else:
            await ctx.channel.purge(limit=1)
            await ctx.send('I have sent {0} Kars'.format(amount))
            users[member.name]["balances"] += amount
            users[ctx.author.name]["balances"] -= amount

            with open("./user.json", "w") as f:
                json.dump(users, f, indent=2)
    else:
        await ctx.channel.purge(limit=1)
        await ctx.send('You don\'t have enough money!')
        author = bot.get_user(ctx.author.id)
        await author.send('```Balance: {0}```'.format(
            users[ctx.author.name]["balances"]))


@bot.command(name='sell', alias='offer', help='Sell something')
async def sell(ctx, name, price):
    id = str(ctx.message.id)
    balances = int(int(price) * (random.randint(4, 6) / 10))
    with open('user.json', 'r') as f:
        users = json.load(f)
    if (users[ctx.author.name]['balances'] - balances) >= 0:
        with open('./product.json', 'r') as f:
            product = json.load(f)

        product[id] = {}
        product[id]['id'] = id
        product[id]['name'] = name
        product[id]['price'] = price
        product[id]['seller'] = ctx.author.name
        product[id]['sellerID'] = ctx.author.id
        product[id]['status'] = True

        with open('./product.json', 'w') as f:
            json.dump(product, f, indent=2)

        users[ctx.author.name]['balances'] -= balances
        balances = users[ctx.author.name]['balances']

        with open('user.json', 'w') as f:
            json.dump(users, f, indent=2)
        channel = bot.get_channel(724101392679174227)

        await channel.send(
            '```Name: {0}\nPrice: {1}\nID: {2}\nSeller: {3}\nStatus: Not taken```'
            .format(name, price, id, ctx.author.name))
        author = bot.get_user(ctx.author.id)
        await author.send(
            '```Name: {0}\nPrice: {1}\nID: {2}\nSeller: {3}\nStatus: Not taken```\n```Balance: {4}```'
            .format(name, price, id, ctx.author.name, balances))
    else:
        author = bot.get_user(ctx.author.id)
        await author.send('```Balance: {0}```'.format(
            users[ctx.author.name]['balances']))


@bot.command(name='buy', alias='take', help='Buy something')
async def buy(ctx, id):
    with open('./product.json', 'r') as f:
        product = json.load(f)

    if id in product:
        if product[id]['status']:
            price = product[id]['price']
            name = product[id]['name']
            sellerName = product[id]['seller']
            sellerID = product[id]['sellerID']
            with open("./user.json", "r") as f:
                users = json.load(f)

            if int(price) > users[ctx.author.name]['balances']:
                await ctx.send('You don\'t have enough money!')
                author = bot.get_user(ctx.author.id)
                await author.send('```Balance: {0}```'.format(
                    users[ctx.author.name]["balances"]))
            else:
                users[ctx.author.name]['balances'] -= int(price)
                users[sellerName]['balances'] += int(price)
                channel = bot.get_channel(724101392679174227)

                await channel.send(
                    '```Name: {0}\nPrice: {1}\nID: {2}\nSeller: {3}\nStatus: Taken```'
                    .format(name, price, id, sellerName))
                seller = bot.get_user(sellerID)
                await seller.send('```{0} bought {1}\nBalance: {2}```'.format(
                    ctx.author.name, name, users[sellerName]['balances']))
                product[id]['status'] = False
                with open('./product.json', 'w') as f:
                    json.dump(product, f, indent=2)

            with open('./user.json', 'w') as f:
                json.dump(users, f, indent=2)
        else:
            await ctx.send('```Product had taken```')
    else:
        await ctx.send('```Product doesn\'t exist```')


@bot.command(name='shop', alias='product', help='Find all the Product')
async def shop(ctx):
    with open('./product.json', 'r') as f:
        product = json.load(f)

    membersdata = []
    prop = ''
    alldata = '```'
    for prop in product:
        membersdata.append(product[prop])
    for data in membersdata:
        if data['status'] == True:
            alldata += 'Name: {0}\nPrice: {1}\nSeller: {2}\nID: {3}\n\n'.format(
                data['name'], data['price'], data['seller'], data['id'])
    alldata += '```'
    if alldata == '``````':
        alldata = 'No data!'
    await ctx.send(alldata)


@bot.command(name='sellrm', help='Remove the product')
async def sellrm(ctx, id):
    with open('./product.json', 'r') as f:
        product = json.load(f)
    aid = ctx.author.id
    if id in product:
        if aid == product[id][
                'sellerID'] or aid == 623823202073706496 or aid == 664644679232520233 or aid == 653086042752286730 or aid == 589760724323139631 or aid == 666186125026525194:
            product[id]['status'] = False
            await ctx.send('```Product Ended```')
            channel = bot.get_channel(724101392679174227)
            await channel.send(
                '```Name: {0}\nPrice: {1}\nID: {2}\nSeller: {3}\nStatus: Taken```'
                .format(product[id]['name'], product[id]['price'],
                        product[id]['id'], product[id]['sellerName']))
        else:
            await ctx.send('```Product doesn\'t exist```')
    else:
        await ctx.send('You don\'t have Permission')


@bot.command(name='giveaway', help='Giveaway Product')
async def giveaway(ctx, member: discord.User, amount):
    amount = int(amount)
    with open('user.json', 'r') as f:
        users = json.load(f)
    if users[ctx.author.name]['balances'] <= amount:
        await ctx.channel.purge(limit=1)
        await ctx.send('```You don\'t have enough money```')
    else:
        await ctx.channel.purge(limit=1)
        await ctx.send('I have sent {0} Kars'.format(amount))
        users[ctx.author.name]['balances'] -= amount
        users[member.name]['balances'] += amount


@bot.command(name='add', help='This command is for Moderators only')
@commands.has_any_role(664411666154520576, 704252490354262086)
async def add(ctx, member: discord.User, amount):
    amount = int(amount)
    if amount < 100000:
        with open('user.json', 'r') as f:
            users = json.load(f)
        users[member.name]['balances'] += amount
        with open('user.json', 'w') as f:
            json.dump(users, f, indent=2)
    else:
        await ctx.send('Don\'t over 100000')


@bot.command(name='del', help='This command is for Moderators only')
@commands.has_any_role(664411666154520576, 704252490354262086)
async def delete(ctx, member: discord.User, amount):
    amount = int(amount)
    with open('user.json', 'r') as f:
        users = json.load(f)
    if users[member.name]['balances'] - amount <= 0:
        users[member.name]['balances'] = 0
    else:
        users[member.name]['balances'] -= amount
    with open('user.json', 'w') as f:
        json.dump(users, f, indent=2)


@bot.command(name='chka', help='This command is for Moderators only')
@commands.has_any_role(664411666154520576, 704252490354262086)
async def chka(ctx, member: discord.User = None):
    if ctx.channel.id == 704958958950940702:
        with open('user.json', 'r') as f:
            users = json.load(f)
        if member == None:
            membersdata = []
            prop = ''
            alldata = '```'
            for prop in users:
                membersdata.append(users[prop])
            for data in membersdata:
                if data['balances'] != 0:
                    alldata += 'Name: {0}\nBalance: {1}\n'.format(
                        data['name'], data['balances'])
            alldata += '```'
            if alldata == '``````':
                alldata = 'No data!'
            await ctx.send(alldata)
        else:
            await ctx.send('```Name: {0}, Balance: {1}```'.format(
                member.name, users[member.name]['balances']))
    else:
        await ctx.send('Can\'t use it here! {0}'.format(ctx.author.mention))


@bot.command(name='reset', help='...')
async def reset(ctx, member: discord.User = None):
    if ctx.author.id == 666186125026525194:
        with open('user.json', 'r') as f:
            users = json.load(f)
        if member == None:
            for membersname in users:
                users[membersname]['balances'] = 0
        else:
            users[member.name]['balances'] = 0
        with open('user.json', 'w') as f:
            json.dump(users, f)
    else:
        await ctx.send('Only Stupid Benz could use this command!')


@bot.command(name='resetp', help='...')
async def resetp(ctx):
    if ctx.author.id == 666186125026525194:
        with open('product.json', 'r') as f:
            product = json.load(f)
        product = {}
        with open('product.json', 'w') as f:
            json.dump(product, f)
    else:
        await ctx.send('Only Stupid Benz could use this command!')


bot.run(TOKEN)
