DataMiner-FeatureExtractor-kv:
C# aplikacija slu�i za ekstrakciju zna�ajki i generiranje trening skupa podataka iz po�etnog skupa fotografija.
Postupak:
Odabrati ulazni direktorij s fotografijama:
	-imena poddirektorija moraju biti uzastopni cijeli brojevi po�ev�i od 1, isto vrijedi i zaimena slika u njima
	-slike moraju biti u JPEG formatu
Odabrati direktorij s datotekom haarcascade_frontalface_alt_tree.xml zbog parametara Haar cascade algoritma.
Odabrati izlazne diraktorije za detektirana lica i generirane zna�ajke.
Odabrati vrstu generiranih zna�ajki.

RUAP-KV-.NET
ASP.NET web aplikacija putem koje korisnik �alje svoju fotografiju cloud servisu za klasifikaciju.
Postupak:
Odabrati fotografiju putem forme za odabir datoteke i kliknuti na gumb Upload.
Na stranici �e se pokazati fotografija politi�ara u �iju klasu ste klasificirani.