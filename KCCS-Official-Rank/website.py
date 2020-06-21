from flask import Flask, jsonify
import multiprocessing as mulP
app = Flask(__name__)


@app.route('/')
def main():
	result = ''
	try:
		f = open('./index.html', 'r')
		result = f.read()
		f.close()
	except:
		result = 'error fetching data.'
	return result


@app.route('/style.css')
def css():
	result = ''
	try:
		f = open('style.css', 'r')
		result = f.read()
		f.close()
	except:
		return 'error fetching data.', 400, {
		    'Content-Type': 'text/plain; charset=utf-8'
		}
	return result, 200, {'Content-Type': 'text/css; charset=utf-8'}


@app.route('/script.js')
def js():
	result = ''
	try:
		f = open('script.js', 'r')
		result = f.read()
		f.close()
	except:
		result = 'error fetching data.', 400, {
		    'Content-Type': 'text/plain; charset=utf-8'
		}
	return result, 200, {'Content-Type': 'text/javascript; charset=utf-8'}


@app.route('/user.json')
def json():
	result = ''
	try:
		f = open('user.json', 'r')
		result = f.read()
		f.close()
	except:
		result = 'error fetching data.', 400, {
		    'Content-Type': 'text/plain; charset=utf-8'
		}
	return result, 200, {'Content-Type': 'application/json; charset=utf-8'}


@app.route('/img/KCCS_Official_Classic.png')
def png():
	result = ''
	try:
		f = open('KCCS_Official_Classic.png', 'r')
		result = f.read()
		f.close()
	except:
		result = 'error fetching data.', 400, {
		    'Content-Type': 'text/plain; charset=utf-8'
		}
	return result, 200, {'Content-Type': 'image/png; charset=utf-8'}


def init():
	return mulP.Process(target=app.run, args=('0.0.0.0', ))
