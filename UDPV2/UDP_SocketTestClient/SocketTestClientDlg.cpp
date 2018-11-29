// SocketTestClientDlg.cpp : implementation file
//

#include "stdafx.h"
#include "SocketTestClient.h"
#include "SocketTestClientDlg.h"
#include <string>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CSocketTestClientDlg dialog




CSocketTestClientDlg::CSocketTestClientDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSocketTestClientDlg::IDD, pParent)
    , m_senddata(_T(""))
    , m_recvData(_T(""))
    , m_portno(1819)
    , m_udpserver(_T("localhost"))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CSocketTestClientDlg::DoDataExchange(CDataExchange* pDX)
{
    CDialog::DoDataExchange(pDX);
    DDX_Text(pDX, IDC_EDIT2, m_senddata);
    DDX_Text(pDX, IDC_EDIT1, m_recvData);
    DDX_Text(pDX, IDC_EDIT4, m_portno);
    DDX_Text(pDX, IDC_EDIT3, m_udpserver);
}

BEGIN_MESSAGE_MAP(CSocketTestClientDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
    ON_BN_CLICKED(IDOK, &CSocketTestClientDlg::OnBnClickedOk)
    ON_BN_CLICKED(IDCANCEL, &CSocketTestClientDlg::OnBnClickedCancel)
END_MESSAGE_MAP()


// CSocketTestClientDlg message handlers

BOOL CSocketTestClientDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CSocketTestClientDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CSocketTestClientDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CSocketTestClientDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CSocketTestClientDlg::OnBnClickedOk()
{
    UpdateData(TRUE);
   
    SOCKET s = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
    if(s == -1)
    {
        AfxMessageBox("Socket Initialiation Error");
    }
    SOCKADDR_IN serveraddr;
    struct hostent *hostentry;

    
    bool bSent = false;
    std::string server = (const char*) m_udpserver;
    int portno = m_portno;
    
    hostentry = gethostbyname(server.c_str());
    char *pipaddr = inet_ntoa (*(struct in_addr *)*hostentry->h_addr_list);

    memset(&serveraddr,0, sizeof(serveraddr));
    serveraddr.sin_family = AF_INET;
    serveraddr.sin_port = htons(portno);
    serveraddr.sin_addr.s_addr = inet_addr(pipaddr);

    char sbuf[1024], rbuf[1024];
    int len = sizeof(SOCKADDR_IN);

    UpdateData(TRUE);
    sprintf(sbuf,"%s\r\n", (const char*) m_senddata);
    if(sendto(s, sbuf, strlen(sbuf), 0,(SOCKADDR*)&serveraddr,len) == strlen(sbuf))
    {
        if(recvfrom(s, rbuf, 1024, 0, (SOCKADDR*)&serveraddr, &len) > 0)
        {
            m_recvData = rbuf;
            UpdateData(FALSE);
        }
    }
    ::closesocket(s);
}


void CSocketTestClientDlg::OnBnClickedCancel()
{
    OnCancel();
}
