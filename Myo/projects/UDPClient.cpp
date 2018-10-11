#include "UDPClient.h"

UDPClient::UDPClient()
{
	// Start WinSock
	int wsOk = WSAStartup(version, &data);
	if (wsOk != 0)
	{
		std::cout << "Can't start Winsock! " << wsOk;
		return;
	}

	// Create a hint structure for the server
	server.sin_family = AF_INET; // AF_INET = IPv4 addresses
	server.sin_port = htons(54000); // Little to big endian conversion
	inet_pton(AF_INET, "127.0.0.1", &server.sin_addr); // Convert from string to byte array

	// Socket creation, note that the socket type is datagram
	out = socket(AF_INET, SOCK_DGRAM, 0);
}

UDPClient::~UDPClient()
{
	closesocket(out);
	WSACleanup();
}

bool UDPClient::Write(std::string s)
{
	int sendOk = sendto(out, s.c_str(), s.size() + 1, 0, (sockaddr*)&server, sizeof(server));

	if (sendOk == SOCKET_ERROR)
	{
		std::cout << "That didn't work! " << WSAGetLastError() << std::endl;
		return false;
	}
	return true;
}
