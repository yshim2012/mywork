package handlefile;

import java.io.FileInputStream;
import java.io.IOException;

public class HandleFile {

	public static void main(String[] args) throws IOException{
		showContent2("C:\\Users\\init\\Desktop\\kucun1.txt");
//		showContent3("C:\\Users\\init\\Desktop\\kucun1.txt");
	}
	private static void showContent2(String path) throws IOException {
		// ����
		FileInputStream fis = new FileInputStream(path);

		// ͨ������ȡ����
		byte[] byt = new byte[10024];
		int len = fis.read(byt);
		for (int i = 0; i < byt.length; i++) {
			System.out.print((char) byt[i]);
		}

		// ʹ����ر���
		fis.close();
	}
	private static void showContent3(String path) throws IOException {
		// ����
		FileInputStream fis = new FileInputStream(path);

		// ͨ������ȡ����
		byte[] byt = new byte[1024];
		// ��ʲô�ط���ʼ�����������
		int start = 5;
		
		// ϣ���������ٸ�(���������ĩβ������û���㹻����)
		int maxLen =20;

		// ʵ�ʴ���˶��ٸ�
		int len = fis.read(byt, start, maxLen);

		for (int i = start; i < start + maxLen; i++) {
			System.out.print((char) byt[i]);
		}

		// ʹ����ر���
		fis.close();
	}
}
