import socket
mySocket = socket.socket()

def connect_socket():
    global conn,addr
    mySocket.bind(('localhost',65434))
    mySocket.listen(5)
    conn , addr = mySocket.accept()
    print("device connected")
    
connect_socket()

msg =bytes("hello from server", 'utf-8')
conn.send(msg)