import socket
import threading
hostname="localhost"
port=65434
def socket_listener():
    global conn
    mySocket = socket.socket()
    mySocket.bind((hostname, port))
    mySocket.listen(5)
    print("Waiting for connection...")
    conn, addr = mySocket.accept()
    print("Device connected")
    #Func(conn)
    conn.close()
    mySocket.close()

thread = threading.Thread(target=socket_listener)
thread.start()
thread.join()