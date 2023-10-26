# SchiaviDelPadel

User: 
	int Id
	string Name
	string Password
	string PhoneNumber
	List<Slot> Slots

Slot:
	int Id
	DateOnly Date
	TimeOnly TimeSlot
	int UserId
	User user

Occorre creare a mano un componente che abbia come righe le fasce orarie nelle quali prenotare uno slot e come colonne la data, poi nel bottone corrspondente si binda il riferimento alla data e alla fascia oraria sempre a mano

Si potrebbe implementare una funzione per fare inviti ad altri utenti (sia inviti mirati
che inviti generali)

Hub:
	int Id
	List<Invitation> Invitations

Invitation: 
	int Id
	int InvitingUserId
	int InvitedUserId
	List<User> InvitedUsers