# Aspose.PDF Translation

*Aspose.PDF Translation* is a free application for [G Suite Marketplace](https://gsuite.google.com/marketplace/) that allows users to translate PDF document from English to other languages. Powered by [Aspose.PDF Cloud](https://products.aspose.cloud/pdf/family) and [GroupDocs.Translation Cloud](https://products.groupdocs.cloud/translation/family).
(**NOTE:** This project contains only backend functionality. Frontend is located [here](https://github.com/).)

## Project description

The backend is a simple REST service that accepts binary form of PDF document as HTTP request body, then communicates with [Aspose.PDF Cloud](https://products.aspose.cloud/pdf/family) to extract text from the PDF and with [GroupDocs.Translation Cloud](https://products.groupdocs.cloud/translation/family) to translate the extracted text.

Frontend part of *Aspose.PDF Translation* provides user interface for PDF document loading and displaying the translated content.

## Setup

The backend requires *App SID* and *App Key* to communicate with Aspose Cloud and another ones to communicate with GroupDocs Cloud. These values must be passed with the help of the following environment variables: `ASPOSE_SID`, `ASPOSE_KEY` and `GROUPDOCS_SID`, `GROUPDOCS_KEY`.

## Usage

The endpoint that the backend is listening must be used in the frontend [source](https://github.com/) to be called from.
