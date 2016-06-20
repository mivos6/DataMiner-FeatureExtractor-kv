DataMiner-FeatureExtractor-kv:
C# aplikacija služi za ekstrakciju znaèajki i generiranje trening skupa podataka iz poèetnog skupa fotografija.
Postupak:
Odabrati ulazni direktorij s fotografijama:
	-imena poddirektorija moraju biti uzastopni cijeli brojevi poèevši od 1, isto vrijedi i zaimena slika u njima
	-slike moraju biti u JPEG formatu
Odabrati direktorij s datotekom haarcascade_frontalface_alt_tree.xml zbog parametara Haar cascade algoritma.
Odabrati izlazne diraktorije za detektirana lica i generirane znaèajke.
Odabrati vrstu generiranih znaèajki.

RUAP-KV-.NET
ASP.NET web aplikacija putem koje korisnik šalje svoju fotografiju cloud servisu za klasifikaciju.
Postupak:
Odabrati fotografiju putem forme za odabir datoteke i kliknuti na gumb Upload.
Na stranici æe se pokazati fotografija politièara u èiju klasu ste klasificirani.