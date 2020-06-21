import website, threading
from time import sleep


def a():
	while True:
		print(end="")
		sleep(300)


t = threading.Thread(target=a)
t.start()
try:
	page = website.init()
	page.start()
except Exception as e:
	print(e)
import bot
