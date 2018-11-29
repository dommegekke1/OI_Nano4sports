// SocketTestClientDlg.h : header file
//

#pragma once


// CSocketTestClientDlg dialog
class CSocketTestClientDlg : public CDialog
{
// Construction
public:
	CSocketTestClientDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_SOCKETTESTCLIENT_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
    CString m_senddata;
    CString m_recvData;
    afx_msg void OnBnClickedOk();
    afx_msg void OnBnClickedCancel();
    int m_portno;
    CString m_udpserver;
};
