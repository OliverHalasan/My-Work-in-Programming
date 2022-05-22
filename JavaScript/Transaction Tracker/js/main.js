// Enter JavaScript for the exercise here...
let errorText = document.createTextNode('');
document.querySelector('.error').appendChild(errorText);
updateTotals();
document.querySelector('.frm-transactions').addEventListener('submit', function (evt) {
    let transactionType = evt.target.elements.type.value,
    transactionAmount = evt.target.elements.currency.value,
    transactionDescription = evt.target.elements.description.value;
    
    if (transactionType === 'debit' || transactionType === 'credit') {
        if (positiveCheck(transactionAmount)) {
            errorText.nodeValue = '';
            createTransaction(transactionType, transactionAmount, transactionDescription);
            updateTotals();
            evt.target.elements.description.value = '';
            evt.target.elements.type.value = '';
            evt.target.elements.currency.value = '';
        }
        else {
            errorText.nodeValue = 'Amount must be a positive number';
        }
    }   
    else {
        errorText.nodeValue = 'Please select a transaction type';
    }
    evt.preventDefault();
});

document.querySelector('.transactions').addEventListener('click', function (evt) {
    let transactionElement;

    if (evt.target.classList.contains('delete')) {
        if (confirm('Are you sure you would like to delete this transaction?')) {
            //Delete transaction
            transactionElement = evt.target.parentNode.parentNode;
            transactionElement.remove();
            updateTotals();
        }
    }
});

function positiveCheck (number) {
    if (number >= 0) {
        return true;
    }
    else {
        return false;
    }
};

function updateTotals() {
    let calculatedDebit = 0,
    calculatedCredit = 0;
    let transactionsDebit = document.querySelectorAll('.debit'),
    transactionsCredit = document.querySelectorAll('.credit');
    let displayDebit = document.querySelector('.debits');
    let displayCredit = document.querySelector('.credits');

    for (transaction = 0; transaction < transactionsDebit.length; transaction++) {
        let amount = transactionsDebit[transaction].children[2].textContent.substring(1);
        calculatedDebit += Number.parseFloat(amount);
    }

    for (transaction = 0; transaction < transactionsCredit.length; transaction++) {
        let amount = transactionsCredit[transaction].children[2].textContent.substring(1);
        calculatedCredit += Number.parseFloat(amount);
    }

    displayDebit.textContent = '$' + calculatedDebit.toFixed(2);
    displayCredit.textContent = '$' + calculatedCredit.toFixed(2);
}

function createTransaction(type, amount, description) {
    let domTransaction = document.createElement('tr'),
    domDescription = document.createElement('td'),
    domType = document.createElement('td'),
    domAmount = document.createElement('td'),
    domDelete = document.createElement('td'),
    domSymbol = document.createElement('i'),

    textType = document.createTextNode(type),
    textAmount = document.createTextNode('$' + Number.parseFloat(amount).toFixed(2)),
    textDescription = document.createTextNode(description);
    
    domTransaction.classList.add(type);
    domAmount.classList.add('amount');
    domDelete.classList.add('tools');
    domSymbol.classList.add('delete', 'fa', 'fa-trash-o');

    domDescription.appendChild(textDescription);
    domType.appendChild(textType);
    domAmount.appendChild(textAmount);

    domDelete.appendChild(domSymbol);
    domTransaction.appendChild(domDescription);
    domTransaction.appendChild(domType);
    domTransaction.appendChild(domAmount);
    domTransaction.appendChild(domDelete);
    document.querySelector('.transactions').children[1].appendChild(domTransaction);
};