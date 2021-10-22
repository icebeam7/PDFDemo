#!/bin/sh

gpg --quiet --batch --yes --decrypt --passphrase="$DECRYPT_KEY" --output ./secrets/PDFDemo.keystore ./secrets/PDFDemo.keystore.gpg

