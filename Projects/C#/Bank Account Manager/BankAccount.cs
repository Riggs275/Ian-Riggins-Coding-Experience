class BankAccount {

  private string Name;
  private int accID;
  private static int accNum = 0;
  private string userID;
  private string Password;
  private double accBalance;

  public BankAccount(string n, string uID, string uPass) {
    Name = n;
    userID = uID;
    Password = uPass;
    accID = accNum++;
  }

  public string getName() {
    return Name;
  }

  public void setName(string epithet) {
    Name = epithet;
  }

  public string getUserID() {
    return userID;
  }

  public void setUserID(string DIresU) {
    userID = DIresU;
  }

  public string getPassword() {
    return Password;
  }

  public void setPassword(string Wordpass) {
    Password = Wordpass;
  }

  public double getBalance() {
    return accBalance;
  }

  public void setBalance(double money) {
    accBalance = money;
  }

  public void addBalance(double money) {
    accBalance += money;
  }

  public int getAccID() {
    return accID;
  }

  public int getAccNum() {
    return accNum;
  }

  public static int getAccNumS() {
    return accNum;
  }

  public static void removeAcc() {
    accNum--;
  }
  
}