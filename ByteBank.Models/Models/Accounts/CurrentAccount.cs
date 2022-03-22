namespace Models;

/// <summary>
/// Defines a Current Account of Byte bank
/// </summary>
public class CurrentAccount {
    public static int AccountsCounter { get; private set;}
    public static double Tax { get; private set; }
    public Customer? Owner { get; set; } // ! Manter uma propriedade somente com o 'get' faz com que essa propriedade se torne 'somente leitura'
    public int Agency { get; } // ! Manter uma propriedade somente com o 'get' faz com que essa propriedade se torne 'somente leitura'
    public int Number { get; } // ! Manter uma propriedade somente com o 'get' faz com que essa propriedade se torne 'somente leitura'
    private double _balance = 100;

    public double Balance {
        get 
        {
            return _balance;
        }
        set
        {
            if(value < 0) return;
            _balance = value;
        }
    }

    /// <summary>
    /// Creates a new instance of CurrentAccount.
    /// </summary>
    /// <exception cref="ArgumentNullException">Exception thrown when <paramref name="owner"/> is null.</exception>
    /// <exception cref="ArgumentException">Exception thrown when <paramref name="agency"/> is lower than, or equal to zero.</exception>
    /// <exception cref="ArgumentException">Exception thrown when <paramref name="number"/> is lower than, or equal to zero.</exception>
    /// <param name="owner">Represents the property <see cref="Owner"/>.Value cannot be null</param>
    /// <param name="agency">Represents the property <see cref="Agency"/>.Value must be greater than 0.</param>
    /// <param name="number">Represents the property <see cref="Number"/>.Value must be greater than 0.</param>
    
    public CurrentAccount(int agency, int number)
    {
        // if (owner is null) throw new ArgumentNullException(nameof(owner), $"Argument cannot be null.");
        if (agency <= 0) throw new ArgumentException($"Argument must be greater than 0.", nameof(agency));
        if (number <= 0) throw new ArgumentException($"Argument must be greater than 0.", nameof(number));

        Agency = agency;
        Number = number;
        AccountsCounter++;
        // Owner = owner;
        Tax = 30/AccountsCounter;
    }

    /// <summary>
    /// WithDraw method.
    /// </summary>
    /// <exception cref="InsufficientBalanceException">Exception thrown when <paramref name="value"/> is greater than <see cref="_balance"/>.</exception>
    /// <exception cref="ArgumentException">Exception thrown when <paramref name="value"/> is lower than, or equal to zero.</exception>
    /// <param name="value"> 
    /// Represents the withdraw <paramref name="value"/>.
    /// Must be lower than the current balance.
    /// Must be greater than 0.
    /// </param>
    public void WithDraw(double value){
        if(_balance < value) {
            throw new InsufficientBalanceException($"Insufficient balance for this opperation.WithDraw amount:{value} - Balance: {_balance}"
                                                    , nameof(value));
        }
        if(value <= 0) throw new ArgumentException($"Invalid amount for this opperation.", nameof(value));
        
        _balance -= value;
    }

/// <summary>
/// Deposit method.
/// </summary>
/// <exception cref="ArgumentException">Exception thrown when <paramref name="value"/> is lower than, or equal to zero.</exception>
/// <param name="value">
/// Represents the amount of money you want to deposit.
/// Must be greater than 0.
/// </param>
    public void Deposit(double value){
        if(value <= 0) throw new ArgumentException($"Invalid amount for this opperation.", nameof(value));
            
        _balance += value;
    }

    /// <summary>
    /// Transfer method.
    /// </summary>
    /// <exception cref="ArgumentNullException">Exception thrown if <paramref name="targetAccount"/> is null.</exception>
    /// <exception cref="ArgumentException">Exception thrown when <paramref name="value"/> is lower than, or equal to zero.</exception>
    /// <param name="value">
    /// Represents the amount of money you want to transfer.
    /// Must be greater than 0.
    /// </param>
    /// <param name="targetAccount">
    /// The target account to tranfer.
    /// Value cannot be null.
    /// </param>
    public void Transfer(double value, CurrentAccount targetAccount){
        if (targetAccount is null) throw new ArgumentNullException(nameof(targetAccount), $"Argument cannot be null.");
        
        try
        {
            WithDraw(value);
        }
        catch (InsufficientBalanceException e)
        {
            /*
            ! throw e;
            * essa linha vai fazer com que o StackTrace exiba o método 'Transfer' como o método que lançou o erro originalmente
            * porém nós sabemos que o "dono" dessa exceção é o método 'WithDraw'.
            */
            /*
            ! Então, para fazer com que a VM do .NET saiba quem é o "dono" da exceção, nós simplesmente utilizamos e 'throw'
            * throw; 
            */

            throw new CurrentAccountException("Invalid opperation.", e);
        }
        targetAccount.Deposit(value);        
    }

    public override bool Equals(object? obj)
    {
        if(!(obj is CurrentAccount) && (obj is null)) return false;
        CurrentAccount newCurrentAccount = obj as CurrentAccount;
        return (Number == newCurrentAccount.Number
                && Agency == newCurrentAccount.Agency);
    }
}
