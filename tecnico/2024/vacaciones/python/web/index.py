from flask import Flask, render_template

app = Flask(__name__)

# @app.route('/')

# def index():
#     # return "Hello, World!"
#     return "uu aaaaaaaaa"

# @app.route('/contacto')

# def contacto():
#     # return "Hello, World!"
#     return "uu contacto"

@app.route('/')
def principal():
    
    return render_template('index.html')

if __name__ == '__main__':
    app.run(debug=True)