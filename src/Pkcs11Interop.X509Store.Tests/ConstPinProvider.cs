﻿/*
 *  Copyright 2017 The Pkcs11Interop Project
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

/*
 *  Written for the Pkcs11Interop project by:
 *  Jaroslav IMRICH <jimrich@jimrich.sk>
 */

using System.Text;

namespace Net.Pkcs11Interop.X509Store.Tests
{
    class ConstPinProvider : IPinProvider
    {
        private byte[] _pin = null;

        public ConstPinProvider(string pin)
        {
            _pin = Encoding.UTF8.GetBytes(pin);
        }

        public GetPinResult GetTokenPin(Pkcs11X509StoreInfo storeInfo, Pkcs11SlotInfo slotInfo, Pkcs11TokenInfo tokenInfo)
        {
            return new GetPinResult(false, false, _pin);
        }

        public GetPinResult GetKeyPin(Pkcs11X509StoreInfo storeInfo, Pkcs11SlotInfo slotInfo, Pkcs11TokenInfo tokenInfo, Pkcs11X509CertificateInfo certificateInfo)
        {
            return new GetPinResult(false, false, _pin);
        }
    }
}