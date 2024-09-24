namespace cs;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var masterHost = new Host(3);
        var slaveHost1 = new Host(4);
        var slaveHost2 = new Host(2);

        float masterClock = 0;
        float slaveClock1 = 0;
        float slaveClock2 = 0;
        float averageClock = 0;

        float correctionValueSlave1 = 0;
        float correctionValueSlave2 = 0;
        float correctionValueMaster = 0;

        while (true)
        {
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true); // true evita que la tecla aparezca en la consola
                Console.WriteLine("Se presionó una tecla. El bucle se detiene.");
                break;
            }

            masterClock = masterHost.virtualClock;
            slaveClock1 = slaveHost1.virtualClock;
            slaveClock2 = slaveHost2.virtualClock;

            // Usa interpolación de cadenas para mostrar los valores
            Console.WriteLine($"Los relojes virtuales valen: Master: {masterClock}, Slave1: {slaveClock1}, Slave2: {slaveClock2}");

            averageClock = (masterClock + slaveClock1 + slaveClock2) / 3; // Calcula el promedio

            correctionValueMaster = masterClock - averageClock;
            correctionValueSlave1 = slaveClock1 - averageClock;
            correctionValueSlave2 = slaveClock2 - averageClock;

            // Aplica las correcciones a los relojes
            masterHost.virtualClock += -correctionValueMaster;
            slaveHost1.virtualClock += -correctionValueSlave1;
            slaveHost2.virtualClock += -correctionValueSlave2;

            // Muestra los valores de corrección
            Console.WriteLine($"Los relojes virtuales se corrigieron: Master: {correctionValueMaster}, Slave1: {correctionValueSlave1}, Slave2: {correctionValueSlave2}");

            Console.WriteLine("===================================================");

            // Muestra los valores después de la corrección
            Console.WriteLine($"Los relojes virtuales valen: Master: {masterHost.virtualClock}, Slave1: {slaveHost1.virtualClock}, Slave2: {slaveHost2.virtualClock}");
            Console.WriteLine($"Los relojes reales valen: Master: {masterHost.realClock}, Slave1: {slaveHost1.realClock}, Slave2: {slaveHost2.realClock}");
            
            // Pausa de 3 segundos
            System.Threading.Thread.Sleep(3000); 

            // Agrega un segundo al reloj real
            masterHost.addASecondToRealClock();
            slaveHost1.addASecondToRealClock();
            slaveHost2.addASecondToRealClock();

            masterHost.addASecondToVirtualClock();
            slaveHost1.addASecondToVirtualClock();
            slaveHost2.addASecondToVirtualClock();

            Console.WriteLine("El bucle está corriendo...");
        }
    }
}
