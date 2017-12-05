package a;

public class B {
	
	A a = new A();
	
	void m() {
		a.a = 5;
	}
	
	public static void main(String...strings) {
		B b = new B();
		b.m();
		System.out.println(b.a.a);
	}
}
