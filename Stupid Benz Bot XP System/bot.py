import discord
import json
import os
import random
from discord.ext import commands

TOKEN = 'NjkxMTExMjc5MzgwNjYwMjU0.XuWHzA.FlgQhiPNuyqsfDwbZaMMbI7bSPQ'
client = commands.Bot(command_prefix = '=')
os.chdir(r'C:\Users\tpwon\OneDrive\文件\GitHub\Stupid-Benz-Bot\Stupid Benz Bot XP System')

@client.event
async def on_ready():
    print('Login as Misaka Mikoto ----------')

@client.event
async def on_member_join(member):
    with open('user.json', 'r') as f:
        users = json.load(f)

    await update_data(users, member)

    with open('user.json', 'w') as f:
        json.dump(users, f)

    channel = client.get_channel(664409663982272513)
    await channel.send('Hey {}, welcome to **The Official KCCS server!!!** :tada::hugging: !\nYou will be muted for 3 minutes so that you may have time to read the **rules** and explore the server.\nHave Fun!'.format(member.mention))

@client.event
async def on_message(message):
    with open('user.json', 'r') as f:
        users = json.load(f)

    await update_data(users, message.author)
    await add_experience(users, message.author, 5)
    await level_up(users, message.author, message.channel)

    with open('user.json', 'w') as f:
        json.dump(users, f)

async def update_data(users, user):
  botname = ['Dyno', 'MEE6', 'Merlin', 'Misaka Mikoto', 'Groovy', 'KCCSdiscSRV']
  if user.name in botname:
    return
  else:
    if not user.name in users:
        users[user.name] = {}
        users[user.name]['user.id'] = user.id
        users[user.name]['user.avatar'] = str(user.avatar_url)
        users[user.name]['experience'] = 0
        users[user.name]['messageno'] = 0
        users[user.name]['level'] = 1
        return users

async def add_experience(users, user, exp):
    users[user.name]['experience'] += exp
    users[user.name]['messageno'] += 1
    return users

async def level_up(users, user, channel):
    experience = users[user.name]['experience']
    lvl_start = users[user.name]['level']
    lvl_end = int(experience ** (1/5))

    if lvl_start < lvl_end:
        channel = client.get_channel(664409663982272513)
        await channel.send('Congratulations to {}! You have just advanced to level {}!'.format(user.mention, lvl_end))
        users[user.name]['level'] = lvl_end
        return users

client.run(TOKEN)
