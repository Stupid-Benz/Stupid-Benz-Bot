import discord
import json
import random
import os
from discord.ext import commands

TOKEN = "NjkxMTExMjc5MzgwNjYwMjU0.Xu4S1A.KeQw02GA9FB37nlcjxZXlB_chD0"
bot = commands.Bot(command_prefix="+")


@bot.event
async def on_ready():
	print("Login in as Misaka Mikoto")


@bot.event
async def on_member_join(member):
	with open("./user.json", "r") as f:
		users = json.load

	await update_data(users, member)

	with open("./user.json", "w") as f:
		json.dump(users, f)

	channel = bot.get_channel(664409663982272513)
	await channel.send(
	    "Hey {}, welcome to **The Official KCCS server!!!** :tada::hugging: !\nYou will be muted for 3 minutes so that you may have time to read the **rules** and explore the server.\nHave Fun!"
	    .format(member.mention))


@bot.event
async def on_message(message):
	with open("./user.json", "r") as f:
		users = json.load(f)

	if not message.author.bot:
		await update_data(users, message.author)
		await add_experience(users, message.author, 5)
		await level_up(users, message.author)

	with open("./user.json", "w") as f:
		json.dump(users, f)

	await bot.process_commands(message)


async def update_data(users, user):
	if not user.name in users:
		users[user.name] = {}
		users[user.name]["name"] = user.name
		users[user.name]["id"] = user.id
		users[user.name]["avatar"] = str(user.avatar_url)
		users[user.name]["exp"] = 0
		users[user.name]["msg"] = 0
		users[user.name]["level"] = 1
		users[user.name]["needExp"] = 0
		users[user.name]["balances"] = 0
		return users


async def add_experience(users, user, exp):
	Exp = users[user.name]["exp"]
	Msg = users[user.name]["msg"]

	if (Msg * 5) != Exp:
		return users
	else:
		users[user.name]["id"] = user.id
		users[user.name]["avatar"] = str(user.avatar_url)
		users[user.name]["exp"] += exp
		users[user.name]["msg"] += 1
		users[user.name]["balances"] += random.randint(1, 10)
		return users


async def level_up(users, user):
	Exp = users[user.name]["exp"]
	lvl_end = (int(Exp**(1 / 4)))
	NeedExp = (lvl_end + 1)**4 - Exp
	users[user.name]["needExp"] = NeedExp
	users[user.name]["level"] = lvl_end
	return users


@bot.command()
async def load(ctx, extension):
	bot.load_extension(f'commands.{extension}')


@bot.command()
async def unload(ctx, extension):
	bot.unload_extension(f'commands.{extension}')


for filename in os.listdir('./commands'):
	if filename.endswith('py'):
		bot.load_extension(f'commands.{filename[:-3]}')


@bot.command()
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
			await ctx.send('I have sent {0} Kar by {1}'.format(amount))
			users[member.name]["balances"] += amount
			users[ctx.author.name]["balances"] -= amount

			with open("./user.json", "w") as f:
				json.dump(users, f)
		else:
			await ctx.channel.purge(limit=1)
			await ctx.send('I have sent {0} Kars'.format(amount))
			users[member.name]["balances"] += amount
			users[ctx.author.name]["balances"] -= amount

			with open("./user.json", "w") as f:
				json.dump(users, f)
	else:
		await ctx.channel.purge(limit=1)
		await ctx.send('You don\'t have enough money')
		authorid = bot.get_user(ctx.author.id)
		await authorid.send('You only have {0}'.format(
		    users[ctx.author.name]["balances"]))


bot.run(TOKEN)
